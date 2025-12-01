using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public class ApplicationDbContext : DbContext
{
    public DbSet<Autore> Autori { get; set; }
    public DbSet<Libro> Libri { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configura Autore
        modelBuilder.Entity<Autore>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Nome).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Cognome).IsRequired().HasMaxLength(100);
            entity.Property(e => e.DataCreazione).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.DataModifica).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        // Configura Libro
        modelBuilder.Entity<Libro>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Titolo).IsRequired().HasMaxLength(200);
            entity.Property(e => e.ISBN).IsRequired().HasMaxLength(13);
            entity.HasIndex(e => e.ISBN).IsUnique();
            entity.Property(e => e.Prezzo).HasPrecision(10, 2);
            entity.Property(e => e.QuantitaDisponibile).HasDefaultValue(0);
            entity.Property(e => e.DataCreazione).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.DataModifica).HasDefaultValueSql("CURRENT_TIMESTAMP");

            // Relazione
            entity.HasOne(l => l.Autore)
                  .WithMany(a => a.Libri)
                  .HasForeignKey(l => l.AutoreId)
                  .OnDelete(DeleteBehavior.SetNull);
        });
    }
}