using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using PlanningPoker.Persistence;

namespace PlanningPoker.Driven_Adapters
{
    public class PlanningPokerAdapter : IPlanningPokerAdapter
    {

        private readonly PlanningPokerDbContext _context;
        private readonly NavigationManager _navigationManager;
        private readonly IdentityContext _identityContext;
        private readonly AuthenticationStateProvider _AuthenticationStateProvider;
        public List<Domain.Game> _Game { get; set; } = new List<Domain.Game>();

        public PlanningPokerAdapter(PlanningPokerDbContext context, NavigationManager navigationManager, IdentityContext identityContext, AuthenticationStateProvider AuthenticationStateProvider)
        {
            _context = context;
            _navigationManager = navigationManager;
            _identityContext = identityContext;
            _AuthenticationStateProvider = AuthenticationStateProvider;
            //_identityContext.Database.EnsureCreated();
            //_context.Database.EnsureCreated();
        }
        public async Task CreateGame(int teamid, int userStoryId)
        {
            var authState = await _AuthenticationStateProvider.GetAuthenticationStateAsync();
            var authStateUser = authState.User;
            var name = authStateUser.Identity.Name;

            var user = await _context.Users
                                  .Where(u => u.UserName == name)
                                  .FirstAsync();

            var team = await _context.Team
                                  .Where(u => u.Id == teamid)
                                  .FirstAsync();

            var userStory = await _context.UserStory
                                  .Where(u => u.Id == userStoryId)
                                  .FirstAsync();

            Domain.Game game = new Domain.Game();
            game.TeamId = teamid;   
            game.UserStoryId = userStoryId;
            game.Created = DateTime.Now;
            game.CreatedBy = name;
            game.PlanningPokerUser = user; 
            game.Team = team; 
            game.Userstory = userStory; 

            _context.Game.Add(game);
            await _context.SaveChangesAsync();
            _navigationManager.NavigateTo("/Games/Index");
        }
        public async Task ReadGame()
        {

            var authState = await _AuthenticationStateProvider.GetAuthenticationStateAsync();
            var authStateUser = authState.User;
            var name = authStateUser.Identity.Name;

            var user = await _context.Users
                                  .Where(u => u.UserName == name)
                                  .FirstAsync();


            _Game = await _context.Game
                                      .Where(t => t.TeamId == user.TeamId)
                                      .ToListAsync();
        }

        public async Task<Domain.Game> ReadGameSingle(int id)
        {
            var game = await _context.Game
                                     .FindAsync(id);
            if (game == null)
            {
                throw new Exception("No Game with this id.");
            }
            return game;

        }
        public async Task UpdateGame(Domain.Game game, int id)
        {
            var dbGame = await _context.UserStory.FindAsync(id);
            if (dbGame == null)
            {
                throw new Exception("Cannot delete a Game that doesn't exist.");
            }
            dbGame.IsDeleted = game.IsDeleted;


            await _context.SaveChangesAsync();
            _navigationManager.NavigateTo("/Games/Index");
        }
    }
}
