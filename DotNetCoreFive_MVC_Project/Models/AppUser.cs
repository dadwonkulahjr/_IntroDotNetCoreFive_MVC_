using DotNetCoreFive_MVC_Project.HelperResource;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetCoreFive_MVC_Project.Models
{
    public class AppUser : IdentityUser
    {
        [Required]
        [Column(name: "Gender", TypeName = "int")]
        public Gender? Gender { get; set; }
        [Required]
        [Column(name: "Street", TypeName = "nvarchar(50)")]
        public Address? Address { get; set; }
       
    }
}
