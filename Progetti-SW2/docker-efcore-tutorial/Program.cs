using System;
using System.Linq;
using System.Collections.Generic;
using docker_efcore_tutorial.Data;
using docker_efcore_tutorial.Models;
using Microsoft.EntityFrameworkCore;

namespace docker_efcore_tutorial;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("=== Docker EF Core One-to-Many Tutorial ===\n");

        try
        {
            // Usa connection string da variabile d'ambiente o default
            var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING") 
                ?? "Server=sql-server;Database=BlogDb;User Id=sa;Password=Your_password123;TrustServerCertificate=True;";

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            using var context = new ApplicationDbContext();
            
            // Esegui migrazioni automatiche (per sviluppo)
            await context.Database.MigrateAsync();
            Console.WriteLine("✓ Database migrato con successo");

            // Test: Recupera tutti i blog con i relativi post
            Console.WriteLine("\n📝 Blogs e Posts:");
            var blogs = await context.Blogs
                .Include(b => b.Posts)
                .ToListAsync();

            foreach (var blog in blogs)
            {
                Console.WriteLine($"\nBlog: {blog.Name} ({blog.Url})");
                Console.WriteLine($"Posts: {blog.Posts.Count}");
                
                foreach (var post in blog.Posts)
                {
                    Console.WriteLine($"  - {post.Title} ({post.PublishedDate:yyyy-MM-dd})");
                }
            }

            // Aggiungi un nuovo blog con post
            Console.WriteLine("\n➕ Aggiungo nuovo blog...");
            var newBlog = new Blog
            {
                Name = "Travel Blog",
                Url = "https://travelblog.com",
                Posts = new List<Post>
                {
                    new Post { Title = "Best Beaches", Content = "Content about beaches...", PublishedDate = DateTime.Now },
                    new Post { Title = "Mountain Hiking", Content = "Content about hiking...", PublishedDate = DateTime.Now }
                }
            };

            context.Blogs.Add(newBlog);
            await context.SaveChangesAsync();
            Console.WriteLine("✓ Nuovo blog aggiunto con 2 posts");

            // Query complessa: Post di un blog specifico
            Console.WriteLine("\n🔍 Post del Tech Blog:");
            var techBlogPosts = await context.Posts
                .Where(p => p.Blog.Name == "Tech Blog")
                .ToListAsync();

            foreach (var post in techBlogPosts)
            {
                Console.WriteLine($"- {post.Title}");
            }

            Console.WriteLine($"\n✅ Operazioni completate con successo!");
            Console.WriteLine($"Totale Blogs: {await context.Blogs.CountAsync()}");
            Console.WriteLine($"Totale Posts: {await context.Posts.CountAsync()}");

        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Errore: {ex.Message}");
            if (ex.InnerException != null)
            {
                Console.WriteLine($"Dettagli: {ex.InnerException.Message}");
            }
        }
    }
}