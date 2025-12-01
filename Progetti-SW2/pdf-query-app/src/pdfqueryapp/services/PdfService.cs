using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using PdfQueryApp.Models;
using System.Text.RegularExpressions;

namespace PdfQueryApp.Services
{
    public class PdfService : IPdfService
    {
        private readonly string _pdfDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Data");

        public async Task<List<PdfData>> ExtractDataFromPdf(string pdfPath)
        {
            var pdfDataList = new List<PdfData>();

            if (!File.Exists(pdfPath))
            {
                throw new FileNotFoundException($"PDF file not found: {pdfPath}");
            }

            using (var pdfReader = new PdfReader(pdfPath))
            using (var pdfDocument = new PdfDocument(pdfReader))
            {
                int totalPages = pdfDocument.GetNumberOfPages();
                
                for (int page = 1; page <= totalPages; page++)
                {
                    var strategy = new SimpleTextExtractionStrategy();
                    var currentPageText = PdfTextExtractor.GetTextFromPage(pdfDocument.GetPage(page), strategy);
                    
                    var pdfData = new PdfData
                    {
                        PageNumber = page,
                        Text = currentPageText,
                        Metadata = ExtractMetadata(currentPageText)
                    };
                    
                    pdfDataList.Add(pdfData);
                    
                    // Log progress
                    Console.WriteLine($"Processed page {page}/{totalPages}");
                }
            }

            return pdfDataList;
        }

        public async Task<QueryResult> ExecuteQuery(string query, List<PdfData> data)
        {
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            var result = new QueryResult();

            try
            {
                // Query semplici per iniziare
                if (query.ToUpper().Contains("CONTAINS"))
                {
                    var match = Regex.Match(query, @"CONTAINS\s+'([^']+)'", RegexOptions.IgnoreCase);
                    if (match.Success)
                    {
                        var searchTerm = match.Groups[1].Value;
                        result.Results = data.Where(d => 
                            d.Text.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                            .ToList();
                    }
                }
                else if (query.ToUpper().Contains("PAGE"))
                {
                    var match = Regex.Match(query, @"PAGE\s*=\s*(\d+)", RegexOptions.IgnoreCase);
                    if (match.Success && int.TryParse(match.Groups[1].Value, out int pageNum))
                    {
                        result.Results = data.Where(d => d.PageNumber == pageNum).ToList();
                    }
                }
                else
                {
                    // Ricerca semplice nel testo
                    result.Results = data.Where(d => 
                        d.Text.Contains(query, StringComparison.OrdinalIgnoreCase))
                        .Take(50) // Limita a 50 risultati
                        .ToList();
                }

                result.TotalMatches = result.Results.Count;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error executing query: {ex.Message}");
                throw;
            }
            finally
            {
                stopwatch.Stop();
                result.ExecutionTime = stopwatch.Elapsed;
            }

            return result;
        }

        public List<string> GetAvailablePdfs()
        {
            if (!Directory.Exists(_pdfDirectory))
            {
                Directory.CreateDirectory(_pdfDirectory);
                return new List<string>();
            }

            return Directory.GetFiles(_pdfDirectory, "*.pdf")
                           .Select(Path.GetFileName)
                           .Where(f => f != null)
                           .Select(f => f!)
                           .ToList();
        }

        private Dictionary<string, string> ExtractMetadata(string text)
        {
            var metadata = new Dictionary<string, string>();
            
            // Estrai date (formato dd/mm/yyyy)
            var datePattern = @"\b\d{2}/\d{2}/\d{4}\b";
            var dates = Regex.Matches(text, datePattern);
            if (dates.Count > 0)
            {
                metadata["DatesFound"] = string.Join(", ", dates.Select(m => m.Value));
            }

            // Estrai email
            var emailPattern = @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b";
            var emails = Regex.Matches(text, emailPattern);
            if (emails.Count > 0)
            {
                metadata["EmailsFound"] = string.Join(", ", emails.Select(m => m.Value));
            }

            // Conta parole
            var wordCount = text.Split(new[] { ' ', '\n', '\r', '\t' }, 
                StringSplitOptions.RemoveEmptyEntries).Length;
            metadata["WordCount"] = wordCount.ToString();

            return metadata;
        }
    }
}