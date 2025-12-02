using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public class ApplicationDbContext : DbContext
{
    public DbSet<Dvd> Utente { get; set; }

    //aggiungi altre classi poco per gestire altre tabelle....

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseMySql(connectionString, 
                    ServerVersion.AutoDetect(connectionString));
        }
    }
}