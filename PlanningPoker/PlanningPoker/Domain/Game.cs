using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PlanningPoker.Domain;
namespace PlanningPoker.Domain
{
    public class Game
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string? CreatedBy { get; set; }
        [Required]
        public UserStory Userstory { get; set; }
        [Required]
        public int UserStoryId { get; set; }
        [Required]
        public Team Team { get; set; }
        [Required]
        public int TeamId { get; set; }
        [Required]
        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }
        [Required]
        public bool IsDeleted { get; set; }

        [ForeignKey("CreatedBy")]
        public virtual PlanningPokerUser PlanningPokerUser { get; set; }
    }
}
