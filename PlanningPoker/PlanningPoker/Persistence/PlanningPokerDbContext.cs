#nullable disable
using Microsoft.EntityFrameworkCore;
namespace PlanningPoker.Persistence
{
    public class PlanningPokerDbContext : DbContext // : IdentityDbContext<aspnetuser>
    {
        public DbSet<Domain.Game> Game { get; set; }
        public DbSet<Domain.Round> Round { get; set; }
        public DbSet<Domain.Team> Team { get; set; }
        public DbSet<Domain.UserStory> UserStory { get; set; }

        public PlanningPokerDbContext(DbContextOptions<PlanningPokerDbContext> options)
            : base(options)
        {

            Database.EnsureCreated();

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Domain.Game>()
                        .HasOne(g => g.Userstory)
                        .WithMany()
                        .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Domain.Game>()
                        .HasOne(g => g.Team)
                        .WithMany()
                        .OnDelete(DeleteBehavior.ClientSetNull);



            modelBuilder.Entity<Domain.Game>()
                                      .Property(g => g.Created)
                                      .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Domain.Round>()
                                      .Property(r => r.PlayedTime)
                                      .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Domain.Team>()
                                      .Property(t => t.Created)
                                      .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Domain.UserStory>()
                                      .Property(us => us.Created)
                                      .HasDefaultValueSql("getdate()");

            //modelBuilder.Entity<aspnetuser>()
            //            .Property(d => d.ImagePath).HasDefaultValue("");

            //modelBuilder.SeedTeam();
            //modelBuilder.SeedUserStory();
            //modelBuilder.SeedRound();
            //modelBuilder.SeedGame();

        }
    }
}
