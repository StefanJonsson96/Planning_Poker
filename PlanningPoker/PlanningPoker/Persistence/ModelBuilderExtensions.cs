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
                        new Team { Id = 1,  Name ="Stefan's Team", },
                        new Team { Id = 2, Name ="Donald Duck's team"},
                        new Team { Id = 3, Name ="Owen's team"},
                        new Team { Id = 4, Name ="Bertil's team"},
                        new Team { Id = 5, Name="Daisey Duck's team"}

                );
        }
        public static void SeedUserStory(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserStory>()
                        .HasData(
                        new UserStory { Id = 1, Title = "Stefan's story", TeamId = 1, Description = "I want the project to use hexagonal architecture!", Priority = 5 },
                        new UserStory { Id = 2, Title = "Donald Duck's story", TeamId = 2, Description = "I want the frontend made in blazor!", Priority = 4 },
                        new UserStory { Id = 3, Title = "Owen's story", TeamId = 3, Description = "I want the page to look good!", Priority = 3 },
                        new UserStory { Id = 4, Title = "Bertil's story", TeamId = 4, Description = "I want to be able to have a profile picture!", Priority = 2 },
                        new UserStory { Id = 5, Title = "Daisey Duck's story", TeamId = 5, Description = "I want pictures of ducks on the page!", Priority = 1 }

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
