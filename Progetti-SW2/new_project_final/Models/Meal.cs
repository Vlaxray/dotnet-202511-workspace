namespace new_project_final.Models;

public class Meal
{
    public int Id { get; set; }
    public string ExternalId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Area { get; set; } = string.Empty;
    public string Instructions { get; set; } = string.Empty;
    public string Thumbnail { get; set; } = string.Empty;
}
