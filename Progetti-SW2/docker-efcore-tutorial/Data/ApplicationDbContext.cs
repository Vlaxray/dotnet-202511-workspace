using System;
using Microsoft.EntityFrameworkCore;
using docker_efcore_tutorial.Models;

namespace docker_efcore_tutorial.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // La connection string sarà sovrascritta in produzione
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=blogtestDB;User Id=sa;Password=ciao;TrustServerCertificate=True;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configurazione della relazione Uno-a-Molti
        modelBuilder.Entity<Blog>()
            .HasMany<Post>(b => b.Posts)
            .WithOne(p => p.Blog)
            .HasForeignKey(p => p.BlogId)
            .OnDelete(DeleteBehavior.Cascade);

        // Aggiungiamo alcuni dati seed
        modelBuilder.Entity<Blog>().HasData(
            new Blog { Id = 1, Name = "Tech Blog", Url = "https://techblog.com" },
            new Blog { Id = 2, Name = "Food Blog", Url = "https://foodblog.com" }
        );

        modelBuilder.Entity<Post>().HasData(
            new Post { Id = 1, Title = "EF Core Introduction", Content = "Content about EF Core...", PublishedDate = DateTime.Now, BlogId = 1 },
            new Post { Id = 2, Title = "Docker Basics", Content = "Content about Docker...", PublishedDate = DateTime.Now, BlogId = 1 },
            new Post { Id = 3, Title = "Best Pizza Recipe", Content = "Content about pizza...", PublishedDate = DateTime.Now, BlogId = 2 }
        );
    }
}