namespace PdfQueryApp.Models
{
    public class PdfData
    {
        public int PageNumber { get; set; }
        public string Text { get; set; } = string.Empty;
        public Dictionary<string, string> Metadata { get; set; }
        public DateTime ExtractionDate { get; set; }
        
        public PdfData()
        {
            Metadata = new Dictionary<string, string>();
            ExtractionDate = DateTime.Now;
        }
    }

    public class QueryResult
    {
        public List<PdfData> Results { get; set; }
        public int TotalMatches { get; set; }
        public TimeSpan ExecutionTime { get; set; }
        
        public QueryResult()
        {
            Results = new List<PdfData>();
        }
    }
}