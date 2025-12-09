using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    // Classi per la risposta API Dragon Ball
    public class Root
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("ki")]
        public string Ki { get; set; }

        [JsonPropertyName("maxKi")]
        public string MaxKi { get; set; }

        [JsonPropertyName("race")]
        public string Race { get; set; }

        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonPropertyName("affiliation")]
        public string Affiliation { get; set; }

        [JsonPropertyName("deletedAt")]
        public object DeletedAt { get; set; }
    }

    // Color utility
    static class Colors
    {
        public static readonly string Reset = "\x1b[0m";
        public static readonly string Bold = "\x1b[1m";
        public static readonly string Cyan = "\x1b[96m";
        public static readonly string Green = "\x1b[92m";
        public static readonly string Yellow = "\x1b[93m";
        public static readonly string White = "\x1b[97m";
        public static readonly string Gray = "\x1b[90m";
    }

    static void PrintCharacter(Root c)
    {
        Console.WriteLine($"{Colors.Cyan}{Colors.Bold}\n=== PERSONAGGIO TROVATO ==={Colors.Reset}");
        Console.WriteLine($"{Colors.Green}Nome: {Colors.White}{c.Name}{Colors.Reset}");
        Console.WriteLine($"{Colors.Green}Razza: {Colors.White}{c.Race}{Colors.Reset}");
        Console.WriteLine($"{Colors.Green}Genere: {Colors.White}{c.Gender}{Colors.Reset}");
        Console.WriteLine($"{Colors.Green}Affiliazione: {Colors.White}{c.Affiliation}{Colors.Reset}\n");
        Console.WriteLine($"{Colors.Green}Descrizione:{Colors.Reset}");
        Console.WriteLine($"{Colors.White}{c.Description}{Colors.Reset}\n");
    }

    static async Task Main(string[] args)
    {
        // CONFIGURAZIONE DATABASE
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        var services = new ServiceCollection();
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

        var serviceProvider = services.BuildServiceProvider();

        // HEADER
        Console.Clear();
        Console.WriteLine($"{Colors.Cyan}{Colors.Bold}");
        Console.WriteLine("=== DRAGON BALL CHARACTER VIEWER ===");
        Console.WriteLine($"{Colors.Reset}");

        Console.Write($"{Colors.Green}→ Inserisci il nome del personaggio: {Colors.Reset}");
        string name = Console.ReadLine()?.Trim();

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine($"{Colors.Yellow}Nome non valido.{Colors.Reset}");
            return;
        }

        using var scope = serviceProvider.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        // CERCO NEL DATABASE
        var dbCharacter = await db.PochoCharacters.FirstOrDefaultAsync(x => x.Name == name);

        if (dbCharacter != null)
        {
            Console.WriteLine($"{Colors.Green}\n✓ Personaggio trovato nel database (niente API).{Colors.Reset}\n");

            var c = new Root
            {
                Id = dbCharacter.CharacterId,
                Name = dbCharacter.Name,
                Race = dbCharacter.Race,
                Gender = dbCharacter.Gender,
                Description = dbCharacter.Description,
                Image = dbCharacter.Image,
                Affiliation = dbCharacter.Affiliation
            };

            PrintCharacter(c);
            return;
        }

        // NON TROVATO → CERCO NELL'API
        Console.WriteLine($"{Colors.Gray}⏳ Recupero dati dall'API...{Colors.Reset}");

        string url = $"https://dragonball-api.com/api/characters?name={name}";

        using var client = new HttpClient();

        try
        {
            var json = await client.GetStringAsync(url);

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var apiResponse = JsonSerializer.Deserialize<ApiResponse>(json, options);

            if (apiResponse == null || apiResponse.Items.Length == 0)
            {
                Console.WriteLine($"{Colors.Yellow}⚠ Nessun personaggio trovato.{Colors.Reset}");
                return;
            }

            var character = apiResponse.Items[0];

            PrintCharacter(character);

            // SALVO NEL DATABASE
            var newDbItem = new PochoCharacter
            {
                CharacterId = character.Id,
                Name = character.Name,
                Race = character.Race,
                Gender = character.Gender,
                Description = character.Description,
                Image = character.Image,
                Affiliation = character.Affiliation
            };

            db.PochoCharacters.Add(newDbItem);
            await db.SaveChangesAsync();

            Console.WriteLine($"{Colors.Green}✓ Salvato nel database.{Colors.Reset}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{Colors.Yellow}✗ Errore: {ex.Message}{Colors.Reset}");
        }
    }

    // Struttura risposta DragonBall API
    public class ApiResponse
    {
        [JsonPropertyName("items")]
        public Root[] Items { get; set; }
    }
}
