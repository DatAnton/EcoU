using System;
namespace EcoU.Models
{
    public class CleaningPlan
    {
        public int Id { get; set; }
        public string PlanName { get; set; }

        public User Creator { get; set; }
        public string CreatorId { get; set; }

        public DateTime PlanDate { get; set; }
        public string Describing { get; set; }

        public Location Location { get; set; }
        public int LocationId { get; set; }

        public string Address { get; set; }
        public string MainPhoto { get; set; }
    }
}
