using PlanningPoker.Domain;

namespace PlanningPoker.Driven_Adapters
{
    public interface ITeamAdapter
    {
        List<Domain.Team> Team { get; set;  }

        Task CreateTeam(Domain.Team team); // CRUD Test
        Task ReadTeam();
        Task<Team> ReadTeamSingle(int id);
        Task UpdateTeam(Domain.Team team, int id);
        Task DeleteTeam(int id);
    }

}
