using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PlanningPoker.Domain
{
    public class UserStory
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        //[Required]
        public Team Team { get; set; }
        [Required]
        public int TeamId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
        [Required]
        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }
        [Range(1, 5)]
        public int Priority { get; set; }

        public int? Points { get; set;  }


    }
}
