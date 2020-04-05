using System;
using System.ComponentModel.DataAnnotations;
using EcoU.Validators;
using Microsoft.AspNetCore.Http;

namespace EcoU.ViewModels
{
    [SignInAge]
    public class SignInViewModel
    {
        [Required(ErrorMessage = "UserName cannot be blank."),
            MinLength(5, ErrorMessage = "Too short (Minimum 5 characters)."),
            MaxLength(25, ErrorMessage = "Too long (Maximum 25 characters).")]
        public string UserName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email cannot be blank.")]
        public string Email { get; set; }

        [MinLength(5, ErrorMessage = "Too short life message"),
            MaxLength(50, ErrorMessage = "Too long life message.")]
        [Required(ErrorMessage = "Fill your life message.")]
        public string LifeMessage { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Password cannot be blank.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords should be the same.")]
        [Required(ErrorMessage = "Password Confirmation cannot be blank.")]
        [DataType(DataType.Password)]
        public string PasswordConfirmation { get; set; }

        [Required(ErrorMessage = "Please choose image for profile.")]
        [Display(Name = "Profile picture.")]
        public IFormFile Avatar { get; set; }

    }
}
