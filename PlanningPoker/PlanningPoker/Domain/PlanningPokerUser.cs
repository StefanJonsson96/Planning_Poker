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
    }
}