using PdfQueryApp.Models;

namespace PdfQueryApp.Services
{
    public interface IPdfService
    {
        Task<List<PdfData>> ExtractDataFromPdf(string pdfPath);
        Task<QueryResult> ExecuteQuery(string query, List<PdfData> data);
        List<string> GetAvailablePdfs();
    }
}