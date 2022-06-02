using PlanningPoker.Domain;
namespace PlanningPoker.Driven_Adapters
{
    public interface IPlanningPokerAdapter
    {
        List<Domain.Game> _Game { get; set; }
        Task CreateGame(int teamid, int userStoryId); // CRUD Test
        Task ReadGame();
        List<Domain.Round> GetRounds(int? gameId);
        Task<Domain.Game> ReadGameSingle(int id);
        Task UpdateGame(Domain.Game game, int id);
        Task DeleteGame(int id);
        Task Vote(int? points, int? gameId);

        Task PlayAgain(int? id);
        Task SaveGame(int id, int? points);


    }
}
