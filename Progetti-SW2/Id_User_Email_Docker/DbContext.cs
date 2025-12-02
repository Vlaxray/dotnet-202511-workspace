using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public class UserEmailDbContext : DbContext
{
    public DbSet<Credenziale> Credenziali { get; set; }


    // OnConfiguring method removed to fix duplicate definition error

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configura Credenziale
        modelBuilder.Entity<Credenziale>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Username).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
        });

    }
}