using System;
using System.ComponentModel.DataAnnotations;
namespace MembershipPlan.Models
{
    public class MembershipPlan
    {
        public int PlanId { get; set; }
        public string PlanName { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Duration { get; set; }

    }

    public class UserMembership
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public int SelecteddPlan { get; set; }
    }
}