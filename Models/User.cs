using System;
using Microsoft.AspNetCore.Identity;
namespace EcoU.Models
{
    public class User : IdentityUser
    {
        public string LifeMessage { get; set; }

    }
}
