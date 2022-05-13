using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PlanningPoker.Domain;
namespace PlanningPoker.Domain
{
    public class Team
    {
        [Required]
        public int Id { get; set; }

        [Required][MaxLength(25)]

        public string Name { get; set; }

        [Required]
        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }
        //[Required]

        //public <List><aspnetuser> Members { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

    }
}
