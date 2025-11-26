using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

class Program
{
    // Classi per la risposta API
    public class QuoteSummaryResponse
    {
        [JsonPropertyName("quoteSummary")]
        public QuoteSummary QuoteSummary { get; set; }
    }

    public class QuoteSummary
    {
        [JsonPropertyName("result")]
        public Result[] Result { get; set; }
    }

    public class Result
    {
        [JsonPropertyName("assetProfile")]
        public AssetProfile AssetProfile { get; set; }

        [JsonPropertyName("summaryProfile")]
        public SummaryProfile SummaryProfile { get; set; }
    }

    public class AssetProfile
    {
        [JsonPropertyName("sector")]
        public string Sector { get; set; }

        [JsonPropertyName("industry")]
        public string Industry { get; set; }

        [JsonPropertyName("longBusinessSummary")]
        public string LongBusinessSummary { get; set; }

        [JsonPropertyName("website")]
        public string Website { get; set; }

        [JsonPropertyName("fullTimeEmployees")]
        public int? FullTimeEmployees { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }
    }

    public class SummaryProfile
    {
        [JsonPropertyName("sector")]
        public string Sector { get; set; }

        [JsonPropertyName("industry")]
        public string Industry { get; set; }
    }

    // Metodi per colori nel terminale
    static class Colors
    {
        public static readonly string Reset = "\x1b[0m";
        public static readonly string Bold = "\x1b[1m";
        public static readonly string Cyan = "\x1b[96m";
        public static readonly string Green = "\x1b[92m";
        public static readonly string Yellow = "\x1b[93m";
        public static readonly string Blue = "\x1b[94m";
        public static readonly string Magenta = "\x1b[95m";
        public static readonly string White = "\x1b[97m";
        public static readonly string Gray = "\x1b[90m";
    }

    static void PrintHeader(string title)
    {
        int width = 80;
        string border = new string('═', width);
        
        Console.WriteLine($"\n{Colors.Cyan}{Colors.Bold}{border}{Colors.Reset}");
        Console.WriteLine($"{Colors.Cyan}{Colors.Bold}  {title.ToUpper()}{Colors.Reset}");
        Console.WriteLine($"{Colors.Cyan}{Colors.Bold}{border}{Colors.Reset}\n");
    }

    static void PrintSection(string title)
    {
        Console.WriteLine($"\n{Colors.Yellow}{Colors.Bold}┌─ {title} ─────────────────────────────────────{Colors.Reset}");
    }

    static void PrintField(string label, string value)
    {
        if (!string.IsNullOrWhiteSpace(value))
        {
            Console.WriteLine($"{Colors.Gray}│{Colors.Reset} {Colors.Green}{label,-20}{Colors.Reset} {Colors.White}{value}{Colors.Reset}");
        }
    }

    static void PrintDescription(string text, int maxWidth = 76)
    {
        if (string.IsNullOrWhiteSpace(text)) return;

        Console.WriteLine($"{Colors.Gray}│{Colors.Reset}");
        var words = text.Split(' ');
        var line = "";   //a

        foreach (var word in words)
        {
            if (line.Length + word.Length + 1 > maxWidth)
            {
                Console.WriteLine($"{Colors.Gray}│{Colors.Reset} {Colors.White}{line.Trim()}{Colors.Reset}");
                line = word + " ";
            }
            else
            {
                line += word + " ";
            }
        }

        if (line.Length > 0)
        {
            Console.WriteLine($"{Colors.Gray}│{Colors.Reset} {Colors.White}{line.Trim()}{Colors.Reset}");
        }
    }

    static void PrintFooter()
    {
        Console.WriteLine($"{Colors.Yellow}{Colors.Bold}└{'─', 78}┘{Colors.Reset}\n");
    }

    static async Task Main()
    {
        // Banner iniziale
        Console.Clear();
        Console.WriteLine($"{Colors.Cyan}{Colors.Bold}");
        Console.WriteLine(@"
    ███████╗████████╗ ██████╗  ██████╗██╗  ██╗    ██╗   ██╗██╗███████╗██╗    ██╗███████╗██████╗ 
    ██╔════╝╚══██╔══╝██╔═══██╗██╔════╝██║ ██╔╝    ██║   ██║██║██╔════╝██║    ██║██╔════╝██╔══██╗
    ███████╗   ██║   ██║   ██║██║     █████╔╝     ██║   ██║██║█████╗  ██║ █╗ ██║█████╗  ██████╔╝
    ╚════██║   ██║   ██║   ██║██║     ██╔═██╗     ╚██╗ ██╔╝██║██╔══╝  ██║███╗██║██╔══╝  ██╔══██╗
    ███████║   ██║   ╚██████╔╝╚██████╗██║  ██╗     ╚████╔╝ ██║███████╗╚███╔███╔╝███████╗██║  ██║
    ╚══════╝   ╚═╝    ╚═════╝  ╚═════╝╚═╝  ╚═╝      ╚═══╝  ╚═╝╚══════╝ ╚══╝╚══╝ ╚══════╝╚═╝  ╚═╝
        ");
        Console.WriteLine($"{Colors.Reset}");

        Console.Write($"{Colors.Magenta}{Colors.Bold}→ Inserisci il simbolo dello stock (es. AAPL): {Colors.Reset}");
        string symbol = Console.ReadLine()?.ToUpper();

        if (string.IsNullOrWhiteSpace(symbol))
        {
            Console.WriteLine($"{Colors.Yellow}⚠ Simbolo non valido.{Colors.Reset}");
            return;
        }

        Console.WriteLine($"\n{Colors.Gray}⏳ Recupero dati per {symbol}...{Colors.Reset}");

        string region = "US";
        string url = $"https://yh-finance.p.rapidapi.com/stock/get-fundamentals?symbol={symbol}&region={region}&modules=assetProfile,summaryProfile";

        using var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("x-rapidapi-key", "2726d63df2mshdcadee91ad6da56p1b3a40jsn2d24942c60d4");
        request.Headers.Add("x-rapidapi-host", "yh-finance.p.rapidapi.com");

        try
        {
            using var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var data = JsonSerializer.Deserialize<QuoteSummaryResponse>(json, options);

            if (data?.QuoteSummary?.Result != null && data.QuoteSummary.Result.Length > 0)
            {
                var result = data.QuoteSummary.Result[0];
                var profile = result.AssetProfile;

                if (profile != null)
                {
                    PrintHeader($"📊 {symbol} - Company Overview");

                    // Sezione Company Info
                    PrintSection("COMPANY INFORMATION");
                    PrintField("Sector:", profile.Sector);
                    PrintField("Industry:", profile.Industry);
                    PrintField("Location:", $"{profile.City}, {profile.State}, {profile.Country}");
                    PrintField("Employees:", profile.FullTimeEmployees?.ToString("N0"));
                    PrintField("Website:", profile.Website);
                    PrintFooter();

                    // Sezione Business Summary
                    PrintSection("BUSINESS SUMMARY");
                    PrintDescription(profile.LongBusinessSummary);
                    PrintFooter();

                    Console.WriteLine($"{Colors.Green}{Colors.Bold}✓ Dati recuperati con successo!{Colors.Reset}\n");
                }
                else
                {
                    Console.WriteLine($"{Colors.Yellow}⚠ Nessun dato trovato per {symbol}.{Colors.Reset}");
                }
            }
            else
            {
                Console.WriteLine($"{Colors.Yellow}⚠ Nessun risultato trovato per {symbol}.{Colors.Reset}");
            }
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"{Colors.Yellow}✗ Errore nella richiesta: {ex.Message}{Colors.Reset}");
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"{Colors.Yellow}✗ Errore nel parsing JSON: {ex.Message}{Colors.Reset}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{Colors.Yellow}✗ Errore imprevisto: {ex.Message}{Colors.Reset}");
        }
    }
}