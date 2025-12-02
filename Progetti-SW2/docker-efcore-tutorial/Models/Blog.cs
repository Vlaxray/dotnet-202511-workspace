namespace docker_efcore_tutorial.Models;

public class Blog
{
    public int Id { get; set; }
    public string Url { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    
    // Relazione Uno-a-Molti: Un Blog ha molti Post
    public List<Post> Posts { get; set; } = new();
}

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime PublishedDate { get; set; }
    
    // Chiave esterna per Blog
    public int BlogId { get; set; }
    
    // Navigazione inversa
    public Blog Blog { get; set; } = null!;
}