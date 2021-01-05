using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace UdemyMVC5UltimateGuide.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Username cannot be blank")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password cannot be blank")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm Password cannot be blank")]
        [Compare("Password", ErrorMessage ="Passwords do not match") ]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Email cannot be blank")]
        [EmailAddress(ErrorMessage ="Invalid format for email")]
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string DateOfBirth { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}