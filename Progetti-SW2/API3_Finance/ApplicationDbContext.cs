using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    // QUESTO COSTRUTTORE È OBBLIGATORIO
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Output_Pocho> Output_Pochos { get; set; }
}