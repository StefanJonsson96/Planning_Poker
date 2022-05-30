using PlanningPoker.Domain;
namespace PlanningPoker.Driven_Adapters
{
    public interface IPlanningPokerAdapter
    {
        List<Domain.Game> _Game { get; set; }
        Task CreateGame(int teamid, int userStoryId); // CRUD Test

        Task ReadGame();
        Task<Domain.Game> ReadGameSingle(int id);
        Task UpdateGame(Domain.Game game, int id);


    }
}
