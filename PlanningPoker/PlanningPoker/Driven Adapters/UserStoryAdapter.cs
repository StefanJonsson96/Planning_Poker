using PlanningPoker.Persistence;
using PlanningPoker.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components;

namespace PlanningPoker.Driven_Adapters
{
    public class UserStoryAdapter : IUserStoryAdapter
    {
        private readonly PlanningPokerDbContext _context;
        private readonly NavigationManager _navigationManager;
        private readonly IdentityContext _identityContext;

        public UserStoryAdapter(PlanningPokerDbContext context, NavigationManager navigationManager, IdentityContext identityContext)
        {
            _context = context;
            _navigationManager = navigationManager;
            _identityContext = identityContext;
            //_identityContext.Database.EnsureCreated();
            //_context.Database.EnsureCreated();
        }
        public List<Domain.UserStory> UserStory { get; set; } = new List<Domain.UserStory>();

        public async Task CreateUserStory(Domain.UserStory userstory)
        {
            _context.UserStory.Add(userstory);
            await _context.SaveChangesAsync();
            _navigationManager.NavigateTo("/UserStorys/Index");
        }
        public async Task ReadUserStory()
        {
            UserStory = await _context.UserStory.ToListAsync();
            

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
    }
}
