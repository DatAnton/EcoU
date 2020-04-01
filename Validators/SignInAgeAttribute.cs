using System;
using System.ComponentModel.DataAnnotations;
using EcoU.ViewModels;

namespace EcoU.Validators
{
    public class SignInAgeAttribute : ValidationAttribute
    {
        public SignInAgeAttribute()
        {
            ErrorMessage = "Your age must be 16.";
        }

        public override bool IsValid(object value)
        {
            SignInViewModel userModel = value as SignInViewModel;
            return userModel.DateOfBirth.AddYears(16) <= DateTime.Now;
        }
    }
}
