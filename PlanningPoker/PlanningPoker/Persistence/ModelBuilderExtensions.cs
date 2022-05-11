using PlanningPoker.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace PlanningPoker.Persistence
{
    public static class ModelBuilderExtensions
    {
        
        public static void SeedTeam(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>()
                        .HasData(
                        new Team { }

                );
        }
        public static void SeedUserStory(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserStory>()
                        .HasData(
                        new UserStory { }

                );
        }
        public static void SeedRound(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Round>()
                        .HasData(
                        new Round { }

                );
        }
        public static void SeedGame(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
                        .HasData(
                        new Game { }

                );
        }
    }
}
