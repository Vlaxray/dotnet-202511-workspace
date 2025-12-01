using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using CigarAnalyzer.Data;
using CigarAnalyzer.Models;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("=== ANALIZZATORE SIGARI CON EF CORE ===");
        
        // Percorso file
        string pdfPath = @"/app/data/listino.pdf";
        
        if (!File.Exists(pdfPath))
        {
            Console.WriteLine($"❌ File non trovato: {pdfPath}");
            return;
        }
        
        try
        {
            Console.WriteLine($"📄 Analisi: {Path.GetFileName(pdfPath)}");
            
            // 1. Leggi e analizza PDF
            var cigars = await AnalyzePdfAsync(pdfPath);
            Console.WriteLine($"✅ Sigari estratti: {cigars.Count}");
            
            // 2. Salva in database
            await SaveToDatabaseAsync(cigars);
            Console.WriteLine("💾 Dati salvati nel database");
            
            // 3. Recupera e mostra i più economici
            await DisplayCheapestCigarsAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Errore: {ex.Message}");
        }
    }
    
    static async Task<List<Cigar>> AnalyzePdfAsync(string pdfPath)
    {
        var cigars = new List<Cigar>();
        var content = await File.ReadAllTextAsync(pdfPath);
        var lines = content.Split('\n');
        
        foreach (var line in lines)
        {
            var cigar = ParseCigarLine(line);
            if (cigar != null)
            {
                cigars.Add(cigar);
            }
        }
        
        return cigars;
    }
    
    static Cigar ParseCigarLine(string line)
    {
        try
        {
            if (!line.Contains("pezzi")) return null;
            
            var match = Regex.Match(line, 
                @"(\d{4,})\s+(.+?)\s+(da\s+(\d+)\s+pezzi)\s+([\d.,]+)\s+([\d.,]+)");
            
            if (match.Success)
            {
                int pieces = int.Parse(match.Groups[4].Value);
                decimal packagePrice = ParseDecimal(match.Groups[6].Value);
                
                return new Cigar
                {
                    Code = match.Groups[1].Value,
                    Name = match.Groups[2].Value.Trim(),
                    PackageInfo = match.Groups[3].Value,
                    PiecesPerPackage = pieces,
                    PricePerKg = ParseDecimal(match.Groups[5].Value),
                    PackagePrice = packagePrice,
                    PricePerPiece = packagePrice / pieces,
                    ValueScore = CalculateValueScore(pieces, packagePrice)
                };
            }
        }
        catch { }
        
        return null;
    }
    
    static decimal ParseDecimal(string value)
    {
        value = value.Replace(".", "").Replace(",", ".");
        return decimal.TryParse(value, out decimal result) ? result : 0;
    }
    
    static decimal CalculateValueScore(int pieces, decimal price)
    {
        if (price <= 0 || pieces <= 0) return 0;
        return pieces * 100 / price; // Più alto = migliore valore
    }
    
    static async Task SaveToDatabaseAsync(List<Cigar> cigars)
    {
        using var context = new CigarContext();
        
        // Crea database se non esiste
        await context.Database.EnsureCreatedAsync();
        
        // Pulisci tabelle vecchie
        await context.Database.ExecuteSqlRawAsync("DELETE FROM Cigars");
        
        // Aggiungi nuovi dati
        await context.Cigars.AddRangeAsync(cigars);
        
        // Crea record analisi
        var analysis = new AnalysisResult
        {
            AnalysisDate = DateTime.UtcNow,
            TotalCigars = cigars.Count,
            AveragePricePerPiece = cigars.Average(c => c.PricePerPiece),
            MinPricePerPiece = cigars.Min(c => c.PricePerPiece),
            MaxPricePerPiece = cigars.Max(c => c.PricePerPiece),
            Cigars = cigars
        };
        
        await context.AnalysisResults.AddAsync(analysis);
        await context.SaveChangesAsync();
    }
    
    static async Task DisplayCheapestCigarsAsync()
    {
        using var context = new CigarContext();
        
        var cheapest = await context.Cigars
            .OrderBy(c => c.PricePerPiece)
            .Take(15)
            .ToListAsync();
        
        Console.WriteLine("\n🏆 TOP 15 SIGARI PIÙ ECONOMICI:");
        Console.WriteLine(new string('═', 80));
        
        foreach (var cigar in cheapest)
        {
            Console.WriteLine($"{cigar.Code} - {cigar.Name}");
            Console.WriteLine($"   {cigar.PiecesPerPackage}pz | €{cigar.PackagePrice:F2} | €{cigar.PricePerPiece:F2}/pezzo");
        }
    }
}