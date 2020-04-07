using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace EcoU.ViewModels
{
    public class CleanPlanViewModel
    {
        [Required(ErrorMessage = "Name of plan cannot be blank!"),
            MaxLength(50, ErrorMessage = "Should be not more 50 characters."),
            MinLength(10, ErrorMessage = "Should be not less 10 characters.")]
        public string PlanName { get; set; }
        [Required(ErrorMessage = "Describing of plan cannot be blank!"),
            MaxLength(300, ErrorMessage = "Should be not more 300 characters."),
            MinLength(25, ErrorMessage = "Should be not less 25 characters.")]
        public string Describing { get; set; }

        [Required(ErrorMessage = "Set a date of your cleaning.")]
        [DataType(DataType.DateTime)]
        public DateTime PlanDate { get; set; }
        [Required(ErrorMessage = "Specify town where cleaning will be take part.")]
        public int LocationId { get; set; }
        [Required(ErrorMessage = "Specify address where cleaning will be take part.")]
        public string Address { get; set; }
        public IFormFile MainPhoto { get; set; }
    }
}
