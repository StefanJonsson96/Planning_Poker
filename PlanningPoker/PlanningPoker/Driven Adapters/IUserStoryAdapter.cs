using PlanningPoker.Domain;

namespace PlanningPoker.Driven_Adapters
{
    public interface IUserStoryAdapter
    {
        List<Domain.UserStory> UserStory { get; set;  }
        public int TeamId { get; set; }
        Task CreateUserStory(Domain.UserStory userstory); // CRUD Test
        Task ReadUserStory();
        Task<UserStory> ReadUserStorySingle(int id);
        Task UpdateUserStory(Domain.UserStory userstory, int id);
        Task DeleteUserStory(int id);
        Task PlayGame(int id);
    }

}
