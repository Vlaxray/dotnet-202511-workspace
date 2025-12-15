using Microsoft.EntityFrameworkCore;
using new_project_final.Models;

namespace new_project_final.Data;

public class AppDbContext : DbContext
{
    public DbSet<Meal> Meals { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
}
