using System;
using System.Collections.Generic;
using EcoU.Models;

namespace EcoU.ViewModels
{
    public class IndexPlansModel
    {
        public IEnumerable<CleaningPlan> Plans { get; set; }
        public int? LocationId { get; set; }
        public string LocationRegionFind { get; set; }
        public string PlanNameFind { get; set; }
    }
}
