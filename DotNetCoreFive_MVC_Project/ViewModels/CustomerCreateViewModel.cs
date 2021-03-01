using DotNetCoreFive_MVC_Project.HelperResource;
using DotNetCoreFive_MVC_Project.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DotNetCoreFive_MVC_Project.ViewModels
{
    public class CustomerCreateViewModel
    {
        [Required]
        [Display(Name = "Customer Name")] 
        public string Name { get; set; }
        [Required]
        [Display(Name = "Customer Email")]
        [EmailAddress(ErrorMessage = "Invaild email.")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Customer Agent")]
        public Agent? Agent { get; set; }
        [DisplayName(displayName:"Photo")]
        public List<IFormFile> Photos { get; set; }
    }
}
