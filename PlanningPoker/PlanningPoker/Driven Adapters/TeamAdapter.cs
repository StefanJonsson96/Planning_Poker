using PlanningPoker.Persistence;
using PlanningPoker.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components;

namespace PlanningPoker.Driven_Adapters
{
    public class TeamAdapter : ITeamAdapter
    {
        private readonly PlanningPokerDbContext _context;
        private readonly NavigationManager _navigationManager;
        private readonly IdentityContext _identityContext;

        public TeamAdapter(PlanningPokerDbContext context, NavigationManager navigationManager, IdentityContext identityContext)
        {
            _context = context;
            _navigationManager = navigationManager;      
            _identityContext = identityContext;
            //_context.Database.EnsureCreated();
            //_identityContext.Database.EnsureCreated();
        }
        public List<Domain.Team> Team { get; set; } = new List<Domain.Team>();

        public async Task CreateTeam(Domain.Team team)
        {
            _context.Team.Add(team);
            await _context.SaveChangesAsync();
            _navigationManager.NavigateTo("/Teams/Index");
        }
        public async Task ReadTeam()
        {
            Team = await _context.Team.ToListAsync();
            

        }

        public async Task<Team> ReadTeamSingle(int id)
        {
            var team = await _context.Team
                                     .FindAsync(id);
            if (team == null)
            {
                throw new Exception("No game with this id.");
            }
            return team;

        }
        public async Task UpdateTeam(Domain.Team team, int id)
        {
            var dbTeam = await _context.Team.FindAsync(id);
            if (dbTeam == null)
            {
                throw new Exception("Cannot delete a team that doesn't exist.");
            }
            dbTeam.Name = team.Name;
            dbTeam.Updated = DateTime.Now;
            dbTeam.IsDeleted = team.IsDeleted;
           
            await _context.SaveChangesAsync();
            _navigationManager.NavigateTo("/Teams/Index");
        }
        public async Task DeleteTeam(int id)
        {
            var dbTeam = await _context.Team.FindAsync(id);
            if (dbTeam == null)
            {
                throw new Exception("Cannot delete a team that doesn't exist.");
            }
            _context.Team.Remove(dbTeam);
            await _context.SaveChangesAsync();
            _navigationManager.NavigateTo("/Teams/Index");

        }
    }
}
