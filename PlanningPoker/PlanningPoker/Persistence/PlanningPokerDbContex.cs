#nullable disable
using Microsoft.EntityFrameworkCore;
namespace PlanningPoker.Persistence
{
    public class PlanningPokerDbContext : DbContext
    // : IdentityDbContext<aspnetuser>
    {
        public DbSet<PlanningPoker.Domain.Games> Game { get; set; }

        public PlanningPokerDbContext(DbContextOptions<PlanningPokerDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
