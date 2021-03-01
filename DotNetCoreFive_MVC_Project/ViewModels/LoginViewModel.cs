using DotNetCoreFive_MVC_Project.Utilities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DotNetCoreFive_MVC_Project.ViewModels
{
    public class LoginViewModel
    {
        [EmailAddress(ErrorMessage ="Email is not valid.")]
        [Required]
        [ValidateEmailAddress(checkEmailAddress: "iamtuse.com", ErrorMessage = "Email domain must be iamtuse.com")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DisplayName(displayName:"Remember Me")]
        public bool RememberMe { get; set; }
    }
}
