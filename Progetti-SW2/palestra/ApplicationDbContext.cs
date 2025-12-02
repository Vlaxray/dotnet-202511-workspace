using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    // DbSet per tutte le entità
    public DbSet<Corso> Corsi { get; set; }
    public DbSet<Membro> Membri { get; set; }
    public DbSet<Istruttore> Istruttori { get; set; }
    public DbSet<Abbonamento> Abbonamenti { get; set; }
    public DbSet<Esercizio> Esercizi { get; set; }
    public DbSet<SchedaAllenamento> SchedeAllenamento { get; set; }
    public DbSet<PartecipazioneCorso> Partecipazioni { get; set; }
    public DbSet<Pagamento> Pagamenti { get; set; }
    public DbSet<Notifica> Notifiche { get; set; }

    // Costruttore pubblico senza parametri necessario per EF Core
    public ApplicationDbContext() { }

    // Configurazione SQL Server
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
                @"Server=localhost,1433;Database=PalestraDB;User Id=sa;Password=Password123;");
        }
    }

    // Configurazioni aggiuntive (facoltativo)
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Esempio: relazione 1:N tra Corso e Partecipazioni
        modelBuilder.Entity<PartecipazioneCorso>()
            .HasOne(p => p.Corso)
            .WithMany(c => c.Partecipazioni)
            .HasForeignKey("CorsoId")
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<PartecipazioneCorso>()
            .HasOne(p => p.Membro)
            .WithMany()
            .HasForeignKey("MembroId")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
