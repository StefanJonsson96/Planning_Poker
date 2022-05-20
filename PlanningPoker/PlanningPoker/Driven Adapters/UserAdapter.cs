using PlanningPoker.Persistence;
using PlanningPoker.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace PlanningPoker.Driven_Adapters
{
    public class UserAdapter : IUserAdapter
    {
        private readonly PlanningPokerDbContext _context;
        private readonly NavigationManager _navigationManager;
        private readonly IdentityContext _identityContext;
        private readonly AuthenticationStateProvider _AuthenticationStateProvider;

        public UserAdapter(PlanningPokerDbContext context, NavigationManager navigationManager, IdentityContext identityContext, AuthenticationStateProvider AuthenticationStateProvider)
        {
            _context = context;
            _navigationManager = navigationManager;
            _identityContext = identityContext;
            _AuthenticationStateProvider = AuthenticationStateProvider;
            //_context.Database.EnsureCreated();
            //_identityContext.Database.EnsureCreated();
        }
        public PlanningPokerUser PlanningPokerUser { get; set; } = new PlanningPokerUser();
        public Team Team { get; set; } = new Team();

        public string TeamName { get; set; }

        public async Task ReadUser()
        {
            //System.Threading.Thread.Sleep(3000);
            var authState = await _AuthenticationStateProvider.GetAuthenticationStateAsync();
            var authStateUser = authState.User;
            var name = authStateUser.Identity.Name;

            PlanningPokerUser = await _context.Users
                                  .Where(u => u.UserName == name)
                                  .FirstAsync();

        }
        public async Task ReadTeam()
        {
            Team = await _context.Team
                                 .Where(t => t.Id == PlanningPokerUser.TeamId)
                                 .FirstAsync();

            TeamName = Team.Name;
        }
        //public async Task UpdateUser(Domain.PlanningPokerUser user, int id)
        //{
        //    var dbUser = await _context.Users.FindAsync(id);
        //    dbUser.Name = user.Name;
        //    dbUser.ImagePath = user.ImagePath;
        //    dbUser.PhoneNumber = user.PhoneNumber;
        //    dbUser.Updated = DateTime.Now;

        //    await _context.SaveChangesAsync();
        //    _navigationManager.NavigateTo("/Account/Profile");
        //}
    }
}
