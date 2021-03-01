using DotNetCoreFive_MVC_Project.HelperResource;
using DotNetCoreFive_MVC_Project.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetCoreFive_MVC_Project.ViewModels
{
    public class RegisterViewModel
    {
        [EmailAddress(ErrorMessage ="Please enter a valid email address")]
        [Required]
        [Remote(action: "CheckUserEmailIsInUse", controller:"Account")]
        [ValidateEmailAddress(checkEmailAddress:"iamtuse.com", ErrorMessage ="Email domain must be iamtuse.com")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Required]
        [Compare(nameof(Password), ErrorMessage ="Password and confirm password must match.")]
        [DisplayName(displayName:"Confirm Password")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "Sex")]
        [Required]
        public Gender? Gender { get; set; }
        [Display(Name = "Street")]
        [Required]
        public Address? Address { get; set; }
    }
}
