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
        public static void SeedUser(this ModelBuilder modelBuilder)
        {
            PlanningPokerUser Stefan = new PlanningPokerUser()
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                UserName = "admin@pp.com",
                NormalizedUserName = "ADMIN@PP.COM",
                Email = "admin@pp.com",
                NormalizedEmail = "ADMIN@PP.COM",
                Name = "Stefan Jonsson",
                LockoutEnabled = false,
                PhoneNumber = "1234567890",
                TeamId = 2,
                ImagePath = "/images/Users/admin.png",
                DOB = new DateTime(1996, 08, 01)
            };

            PlanningPokerUser TeamLeader = new PlanningPokerUser()
            {
                Id = "TeamLeader",
                UserName = "tl@pp.com",
                NormalizedUserName = "TL@PP.COM",
                Email = "tl@PP.com",
                NormalizedEmail = "TL@PP.COM",
                Name = "Team Leader",
                LockoutEnabled = false,
                PhoneNumber = "5559561190",
                TeamId = 1,
                // ImagePath = "/images/Users/admin.png", WIP
                DOB = new DateTime(1973, 03, 13)
            };

            PlanningPokerUser User = new PlanningPokerUser()
            {
                Id = "User",
                UserName = "user@pp.com",
                NormalizedUserName = "USER@PP.COM",
                Email = "user@pp.com",
                NormalizedEmail = "USER@PP.COM",
                Name = "User",
                LockoutEnabled = false,
                PhoneNumber = "1119561190",
                TeamId = 1,
                // ImagePath = "/images/Users/admin.png", WIP
                DOB = new DateTime(1973, 03, 13)
            };

            PasswordHasher<PlanningPokerUser> passwordHasher = new PasswordHasher<PlanningPokerUser>();
            Stefan.PasswordHash = passwordHasher.HashPassword(Stefan, ".");
            TeamLeader.PasswordHash = passwordHasher.HashPassword(TeamLeader, ".");
            User.PasswordHash = passwordHasher.HashPassword(User, ".");

            modelBuilder.Entity<PlanningPokerUser>().HasData(Stefan, TeamLeader, User);
        }
        public static void SeedRole(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>()
                        .HasData(
                        new IdentityRole { Id = "inz5jyo9-c546-41de-aebc-a14da6895711", Name="Admin", ConcurrencyStamp = "1", NormalizedName ="Admin" },
                        new IdentityRole { Id = "dca3qpo1-c546-41de-aebc-a14da6895711", Name = "TeamLeader", ConcurrencyStamp = "2", NormalizedName = "TeamLeader" }

                );
        }
        public static void SeedUserRole(this ModelBuilder modelBuilder)
        {
                modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = "inz5jyo9-c546-41de-aebc-a14da6895711", UserId = "b74ddd14-6340-4840-95c2-db12554843e5" },
                new IdentityUserRole<string>() { RoleId = "dca3qpo1-c546-41de-aebc-a14da6895711", UserId =  "TeamLeader"}
                );
        }

    }
}
