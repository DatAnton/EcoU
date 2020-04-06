using System;
using System.Collections;
using System.Collections.Generic;
namespace EcoU.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Town { get; set; }
        public string Region { get; set; }
        public List<CleaningPlan> CleaningPlans { get; set; }
    }
}
