using CigarAnalyzer.Models;
using Microsoft.EntityFrameworkCore;

namespace CigarAnalyzer.Data
{
    public class CigarContext : DbContext
    {
        public DbSet<Cigar> Cigars { get; set; }
        public DbSet<AnalysisResult> AnalysisResults { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Per Docker: usa SQL Server in container
            optionsBuilder.UseSqlServer(
                "Server=localhost,1433;Database=CigarDb;User Id=sa;Password=YourPassword123!;TrustServerCertificate=true;",
                options => options.EnableRetryOnFailure()
            );
            
            // Per SQLite (più semplice):
            // optionsBuilder.UseSqlite("Data Source=cigars.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cigar>()
                .HasIndex(c => c.Code)
                .IsUnique();
                
            modelBuilder.Entity<Cigar>()
                .HasIndex(c => c.PricePerPiece);
                
            modelBuilder.Entity<Cigar>()
                .HasIndex(c => c.ValueScore);
                
            modelBuilder.Entity<AnalysisResult>()
                .HasMany(ar => ar.Cigars)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}