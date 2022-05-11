using PlanningPoker.Domain;

namespace PlanningPoker.Driven_Adapters
{
    public interface ITest
    {
        List<Team> Team { get; set;  }

        Task CreateTeam(Team team); // CRUD Test
        Task ReadTeam();
        Task UpdateTeam(Team team, int id);
        Task DeleteTeam(int id);
    }

}
