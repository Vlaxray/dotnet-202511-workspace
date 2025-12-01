using Microsoft.EntityFrameworkCore;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("=== GESTIONE LIBRERIA CON EF CORE ===");

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
                Console.WriteLine("1. Visualizza tutti i libri");
                Console.WriteLine("2. Visualizza tutti gli autori");
                Console.WriteLine("3. Aggiungi autore");
                Console.WriteLine("4. Aggiungi libro");
                Console.WriteLine("5. Cerca libro per titolo");
                Console.WriteLine("6. Statistiche");
                Console.WriteLine("0. Esci");
                Console.Write("Scelta: ");

                var scelta = Console.ReadLine();

                switch (scelta)
                {
                    case "1":
                        await VisualizzaLibri(db);
                        break;
                    case "2":
                        await VisualizzaAutori(db);
                        break;
                    case "3":
                        await AggiungiAutore(db);
                        break;
                    case "4":
                        await AggiungiLibro(db);
                        break;
                    case "5":
                        await CercaLibro(db);
                        break;
                    case "6":
                        await MostraStatistiche(db);
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

    static async Task VisualizzaLibri(ApplicationDbContext db)
    {
        Console.WriteLine("\n=== LISTA LIBRI ===");
        var libri = await db.Libri
            .Include(l => l.Autore)
            .OrderBy(l => l.Titolo)
            .ToListAsync();

        if (!libri.Any())
        {
            Console.WriteLine("Nessun libro trovato.");
            return;
        }

        foreach (var libro in libri)
        {
            Console.WriteLine($"ID: {libro.Id}");
            Console.WriteLine($"  Titolo: {libro.Titolo}");
            Console.WriteLine($"  Autore: {libro.Autore?.NomeCompleto ?? "N/D"}");
            Console.WriteLine($"  ISBN: {libro.ISBN}");
            Console.WriteLine($"  Prezzo: €{libro.Prezzo:F2}");
            Console.WriteLine($"  Disponibili: {libro.QuantitaDisponibile}");
            Console.WriteLine("---");
        }
    }

    static async Task VisualizzaAutori(ApplicationDbContext db)
    {
        Console.WriteLine("\n=== LISTA AUTORI ===");
        var autori = await db.Autori
            .Include(a => a.Libri)
            .OrderBy(a => a.Cognome)
            .ThenBy(a => a.Nome)
            .ToListAsync();

        if (!autori.Any())
        {
            Console.WriteLine("Nessun autore trovato.");
            return;
        }

        foreach (var autore in autori)
        {
            Console.WriteLine($"ID: {autore.Id}");
            Console.WriteLine($"  Nome: {autore.NomeCompleto}");
            Console.WriteLine($"  Email: {autore.Email ?? "N/D"}");
            Console.WriteLine($"  Libri pubblicati: {autore.Libri.Count}");
            Console.WriteLine("---");
        }
    }

    static async Task AggiungiAutore(ApplicationDbContext db)
    {
        Console.WriteLine("\n=== AGGIUNGI AUTORE ===");
        
        Console.Write("Nome: ");
        var nome = Console.ReadLine();
        
        Console.Write("Cognome: ");
        var cognome = Console.ReadLine();
        
        Console.Write("Email (opzionale): ");
        var email = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(cognome))
        {
            Console.WriteLine("Nome e cognome sono obbligatori!");
            return;
        }

        var autore = new Autore
        {
            Nome = nome.Trim(),
            Cognome = cognome.Trim(),
            Email = string.IsNullOrWhiteSpace(email) ? null : email.Trim()
        };

        db.Autori.Add(autore);
        await db.SaveChangesAsync();
        
        Console.WriteLine($"Autore aggiunto con ID: {autore.Id}");
    }

    static async Task AggiungiLibro(ApplicationDbContext db)
    {
        Console.WriteLine("\n=== AGGIUNGI LIBRO ===");
        
        Console.Write("Titolo: ");
        var titolo = Console.ReadLine();
        
        Console.Write("ISBN: ");
        var isbn = Console.ReadLine();
        
        Console.Write("Prezzo: ");
        var prezzoInput = Console.ReadLine();
        
        Console.Write("Quantità disponibile: ");
        var quantitaInput = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(titolo) || string.IsNullOrWhiteSpace(isbn))
        {
            Console.WriteLine("Titolo e ISBN sono obbligatori!");
            return;
        }

        if (!decimal.TryParse(prezzoInput, out decimal prezzo) || prezzo < 0)
        {
            Console.WriteLine("Prezzo non valido!");
            return;
        }

        if (!int.TryParse(quantitaInput, out int quantita) || quantita < 0)
        {
            Console.WriteLine("Quantità non valida!");
            return;
        }

        // Mostra autori disponibili
        Console.WriteLine("\nAutori disponibili:");
        var autori = await db.Autori.ToListAsync();
        foreach (var autore in autori)
        {
            Console.WriteLine($"ID {autore.Id}: {autore.NomeCompleto}");
        }
        
        Console.Write("ID Autore (premi Invio per nessuno): ");
        var autoreIdInput = Console.ReadLine();

        var libro = new Libro
        {
            Titolo = titolo.Trim(),
            ISBN = isbn.Trim(),
            Prezzo = prezzo,
            QuantitaDisponibile = quantita,
            AutoreId = string.IsNullOrWhiteSpace(autoreIdInput) ? null : int.Parse(autoreIdInput)
        };

        db.Libri.Add(libro);
        await db.SaveChangesAsync();
        
        Console.WriteLine($"Libro aggiunto con ID: {libro.Id}");
    }

    static async Task CercaLibro(ApplicationDbContext db)
    {
        Console.Write("\nCerca libro per titolo: ");
        var ricerca = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(ricerca))
        {
            Console.WriteLine("Inserisci un termine di ricerca!");
            return;
        }

        var libri = await db.Libri
            .Include(l => l.Autore)
            .Where(l => l.Titolo.Contains(ricerca))
            .ToListAsync();

        Console.WriteLine($"\nTrovati {libri.Count} libri:");

        foreach (var libro in libri)
        {
            Console.WriteLine($"- {libro.Titolo} (ISBN: {libro.ISBN}) di {libro.Autore?.NomeCompleto ?? "Autore sconosciuto"}");
        }
    }

    static async Task MostraStatistiche(ApplicationDbContext db)
    {
        Console.WriteLine("\n=== STATISTICHE ===");
        
        var numeroLibri = await db.Libri.CountAsync();
        var numeroAutori = await db.Autori.CountAsync();
        var valoreInventario = await db.Libri.SumAsync(l => l.Prezzo * l.QuantitaDisponibile);
        var libroPiuCostoso = await db.Libri.OrderByDescending(l => l.Prezzo).FirstOrDefaultAsync();

        Console.WriteLine($"Numero totale libri: {numeroLibri}");
        Console.WriteLine($"Numero totale autori: {numeroAutori}");
        Console.WriteLine($"Valore inventario: €{valoreInventario:F2}");
        
        if (libroPiuCostoso != null)
        {
            Console.WriteLine($"Libro più costoso: {libroPiuCostoso.Titolo} (€{libroPiuCostoso.Prezzo:F2})");
        }
    }
}