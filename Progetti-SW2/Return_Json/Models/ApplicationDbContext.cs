using Microsoft.EntityFrameworkCore;

namespace Return_Json.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
        }

        public DbSet<DragonBallCharacter> DragonBallCharacters { get; set; }
    }
}