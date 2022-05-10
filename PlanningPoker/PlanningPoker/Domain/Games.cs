using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PlanningPoker.Domain
{
    public class Games
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string? CreatedBy { get; set; }

        //[ForeignKey("CreatedBy")]
        //public virtual aspnetuser aspnetuser { get; set; }
    }
}
