using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    // QUESTO COSTRUTTORE È OBBLIGATORIO
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<PochoCharacter> PochoCharacters { get; set; }
}