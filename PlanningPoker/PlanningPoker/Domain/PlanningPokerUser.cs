using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace PlanningPoker.Domain
{
    public class PlanningPokerUser : IdentityUser
    {
        [Required]
        [PersonalData]
        public string? Name { get; set; }
        [PersonalData]
        public DateTime DOB { get; set; }
        public string? ImagePath { get; set; }

        [Required]
        public int TeamId { get; set; }

        public DateTime Updated { get; set; }

        public static implicit operator string(PlanningPokerUser v)
        {
            throw new NotImplementedException();
        }
    }
}