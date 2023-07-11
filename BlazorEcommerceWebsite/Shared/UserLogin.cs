using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorEcommerceWebsite.Shared
{
    public class UserLogin
    {
        public UserLogin()
        {
        }

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}

