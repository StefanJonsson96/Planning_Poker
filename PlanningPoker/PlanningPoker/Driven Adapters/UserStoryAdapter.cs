using PlanningPoker.Persistence;
using PlanningPoker.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;


namespace PlanningPoker.Driven_Adapters
{
    public class UserStoryAdapter : IUserStoryAdapter
    {
        private readonly PlanningPokerDbContext _context;
        private readonly NavigationManager _navigationManager;
        private readonly IdentityContext _identityContext;
        private readonly AuthenticationStateProvider _AuthenticationStateProvider;

        public UserStoryAdapter(PlanningPokerDbContext context, NavigationManager navigationManager, IdentityContext identityContext, AuthenticationStateProvider AuthenticationStateProvider)
        {
            _context = context;
            _navigationManager = navigationManager;
            _identityContext = identityContext;
            _AuthenticationStateProvider = AuthenticationStateProvider;
            //_identityContext.Database.EnsureCreated();
            //_context.Database.EnsureCreated();
        }
        public List<Domain.UserStory> UserStory { get; set; } = new List<Domain.UserStory>();
        public int TeamId { get; set; }

        public async Task CreateUserStory(Domain.UserStory userstory)
        {
            _context.UserStory.Add(userstory);
            await _context.SaveChangesAsync();
            _navigationManager.NavigateTo("/UserStorys/Index");
        }
        public async Task ReadUserStory()
        {

            var authState = await _AuthenticationStateProvider.GetAuthenticationStateAsync();
            var authStateUser = authState.User;
            var name = authStateUser.Identity.Name;

            var user = await _context.Users
                                  .Where(u => u.UserName == name)
                                  .FirstAsync();


            TeamId = user.TeamId;

            UserStory = await _context.UserStory
                                      .Where(t => t.TeamId == user.TeamId)
                                      .ToListAsync();
        }

        public async Task<UserStory> ReadUserStorySingle(int id)
        {
            var userstory = await _context.UserStory
                                     .FindAsync(id);
            if (userstory == null)
            {
                throw new Exception("No user story with this id.");
            }
            return userstory;

        }
        public async Task UpdateUserStory(Domain.UserStory userstory, int id)
        {
            var dbUserStory = await _context.UserStory.FindAsync(id);
            if (dbUserStory == null)
            {
                throw new Exception("Cannot delete a user story that doesn't exist.");
            }
            dbUserStory.Title = userstory.Title;
            dbUserStory.Updated = DateTime.Now;
            dbUserStory.IsDeleted = userstory.IsDeleted;
            dbUserStory.Description = userstory.Description;
            dbUserStory.Priority = userstory.Priority;
            
           
            await _context.SaveChangesAsync();
            _navigationManager.NavigateTo("/UserStorys/Index");
        }
        public async Task DeleteUserStory(int id)
        {
            var dbUserStory = await _context.UserStory.FindAsync(id);
            if (dbUserStory == null)
            {
                throw new Exception("Cannot delete a user story that doesn't exist.");
            }
            _context.UserStory.Remove(dbUserStory);
            await _context.SaveChangesAsync();
            _navigationManager.NavigateTo("/UserStorys/Index");

        }

        public async Task PlayGame(int id)
        {
            // Hehheheheheh
        }
    }
}
