using Microsoft.EntityFrameworkCore;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("=== GESTIONE Credenziali CON EF CORE ===");

        try
        {
            using var db = new ApplicationDbContext();

            // Verifica connessione e crea database
            Console.WriteLine("Connessione al database...");
            await db.Database.EnsureCreatedAsync();
            Console.WriteLine("Database connesso e pronto!");

            bool continua = true;
            while (continua)
            {
                Console.WriteLine("\n=== MENU PRINCIPALE ===");
                Console.WriteLine("1. Visualizza tutte le credenziali");
                Console.WriteLine("2. Aggiungi Utente"); //4
                Console.WriteLine("0. Esci");
                Console.Write("Scelta: ");

                var scelta = Console.ReadLine();

                switch (scelta)
                {
                    case "1":
                        await VisualizzaCredenziali(db);
                        break;
                    case "4":
                        await AggiungiUtente(db);
                        break;
                    case "0":
                        continua = false;
                        break;
                    default:
                        Console.WriteLine("Scelta non valida!");
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ERRORE: {ex.Message}");
            if (ex.InnerException != null)
                Console.WriteLine($"Dettaglio: {ex.InnerException.Message}");
        }
    }

    static async Task VisualizzaCredenziali(ApplicationDbContext db)
    {
        Console.WriteLine("\n=== LISTA CREDENZIALI ===");

        var credenziali = await db.Credenziali.ToListAsync();

        if (!credenziali.Any())
        {
            Console.WriteLine("Nessun utente trovato.");
            return;
        }

        foreach (var c in credenziali)
        {
            Console.WriteLine($"ID: {c.Id}");
            Console.WriteLine($"Username: {c.Username}");
            Console.WriteLine($"Email: {c.Email}");
            Console.WriteLine("---");
        }
    }


    static async Task AggiungiUtente(ApplicationDbContext db)
    {
        Console.WriteLine("\n=== AGGIUNGI Utente ===");

        Console.Write("Username: ");
        var Username = Console.ReadLine();

        Console.Write("Email: ");
        var Email = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Email))
        {
            Console.WriteLine("Username e email sono obbligatori");
            return;
        }
        var nuovaCredenziale = new Credenziale { Username = Username, Email = Email };
        db.Credenziali.Add(nuovaCredenziale);
        await db.SaveChangesAsync();

        Console.WriteLine($"Autore aggiunto con ID: {nuovaCredenziale.Id}");
    }
}