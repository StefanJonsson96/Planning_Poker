using PlanningPoker.Persistence;
using PlanningPoker.Domain;
using Microsoft.EntityFrameworkCore;

namespace PlanningPoker.Driven_Adapters
{
    public class Test : ITest
    {
        private readonly PlanningPokerDbContext _context;

        public Test(PlanningPokerDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }
        public List<Team> Team { get; set; } = new List<Team>();
        
        public async Task CreateTeam(Team team)
        {
            _context.Team.Add(team);
            await _context.SaveChangesAsync();
        }
        public async Task ReadTeam()
        {
            Team = await _context.Team.ToListAsync();
        }
        public async Task UpdateTeam(Team team, int id)
        {
            var dbTeam = await _context.Team.FindAsync(id);
            if (dbTeam != null)
            {
                throw new Exception("Försöker du ändra ett team som inte finns?");
            }
            dbTeam.Name = team.Name;
            dbTeam.Updated = DateTime.Now;
            dbTeam.IsDeleted = team.IsDeleted;
           
            await _context.SaveChangesAsync();
        }
        public async Task DeleteTeam(int id)
        {
            var dbTeam = await _context.Team.FindAsync(id);
            if (dbTeam != null)
            {
                throw new Exception("Försöker du ta bort ett team som inte finns?");
            }
            _context.Team.Remove(dbTeam);
            await _context.SaveChangesAsync();

        }
    }
}
