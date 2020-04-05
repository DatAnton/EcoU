using System;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace EcoU.Models
{
    public class User : IdentityUser
    {
        public string LifeMessage { get; set; }
        [Required(ErrorMessage = "Please choose profile image.")]
        public string ProfilePicture { get; set; }

    }
}
