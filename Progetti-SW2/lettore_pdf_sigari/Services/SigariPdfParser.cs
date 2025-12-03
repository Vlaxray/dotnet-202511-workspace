using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using SigariListaPreziApp.Models;

namespace SigariListaPreziApp.Services
{
    public class SigariPdfParser
    {
        public List<Sigaro> ParsePdf(string pdfPath)
        {
            var sigari = new List<Sigaro>();

            try
            {
                using (PdfReader reader = new PdfReader(pdfPath))
                using (PdfDocument pdfDoc = new PdfDocument(reader))
                {
                    for (int page = 1; page <= pdfDoc.GetNumberOfPages(); page++)
                    {
                        string text = PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(page));
                        var lines = text.Split('\n');

                        foreach (var line in lines)
                        {
                            var sigaro = ParseLine(line);
                            if (sigaro != null)
                                sigari.Add(sigaro);
                        }
                    }
                }

                return sigari;
            }
            catch (Exception ex)
            {
                throw new Exception($"Errore nel parsing del PDF: {ex.Message}", ex);
            }
        }

        private Sigaro? ParseLine(string line)
        {
            // Pattern per matchare: CODICE NOME da X pezzi/pezzo PREZZO1 PREZZO2
            var pattern = @"^(\d+)\s+(.+?)\s+da\s+(\d+)\s+pezz[io]\s+([\d,.]+)\s+([\d,.]+)$";
            var match = Regex.Match(line.Trim(), pattern);

            if (!match.Success)
                return null;

            try
            {
                return new Sigaro
                {
                    Codice = int.Parse(match.Groups[1].Value),
                    Nome = match.Groups[2].Value.Trim(),
                    Confezione = $"da {match.Groups[3].Value} pezzi",
                    Pezzi = int.Parse(match.Groups[3].Value),
                    PrezzoKgConvenzionale = ParseDecimal(match.Groups[4].Value),
                    PrezzoConfezione = ParseDecimal(match.Groups[5].Value)
                };
            }
            catch
            {
                return null;
            }
        }

        private decimal ParseDecimal(string value)
        {
            // Gestisce formato italiano: 2.400,00 -> 2400.00
            value = value.Replace(".", "").Replace(",", ".");
            return decimal.Parse(value, CultureInfo.InvariantCulture);
        }
    }
}