using PlanningPoker.Domain;

namespace PlanningPoker.Driven_Adapters
{
    public interface IUserAdapter
    {
        PlanningPokerUser PlanningPokerUser { get; set; }
        Team Team { get; set; }
        string TeamName { get; set; }
        Task ReadUser();
        Task ReadTeam();
        List<PlanningPokerUser> GetUserFromTeam(int teamId);

        //Task UpdateUser(Domain.PlanningPokerUser user, int id);
    }

}
