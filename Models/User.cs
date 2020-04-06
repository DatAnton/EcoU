using System;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Collections;
using System.Collections.Generic;

namespace EcoU.Models
{
    public class User : IdentityUser
    {
        public string LifeMessage { get; set; }
        [Required(ErrorMessage = "Please choose profile image.")]
        public string ProfilePicture { get; set; }
        public List<CleaningPlan> CleaningPlans { get; set; }

    }
}
