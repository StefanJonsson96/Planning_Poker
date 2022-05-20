using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PlanningPoker.Domain;
namespace PlanningPoker.Domain
{
    public class Round
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public Game Game { get; set; }
        [Required]
        public int GameId { get; set; }

        [ForeignKey("PlayedBy")]
        public virtual PlanningPokerUser PlanningPokerUser { get; set; }

        [Required]
        public int Points { get; set; }

        [Required]
        public DateTime PlayedTime { get; set; }

        public bool IsDeleted { get; set; }
    }

}
