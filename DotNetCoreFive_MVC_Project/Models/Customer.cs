using DotNetCoreFive_MVC_Project.HelperResource;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetCoreFive_MVC_Project.Models
{
    public class Customer
    {
        [Column(name: "Customer ID", TypeName = "int")]
        public int ID { get; set; }
        [Required]
        [Display(Name = "Customer Name")]
        [MaxLength(50, ErrorMessage ="Name cannot exceed 50 characters!")]
        [Column(name:"Customer Name", TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Customer Email")]
        [Column(name: "Customer Email", TypeName = "nvarchar(50)")]
        [EmailAddress(ErrorMessage ="Invaild email.")]
        public string Email { get; set; }
        [Required]
        [Column(name: "Customer Agent", TypeName = "int")]
        [Display(Name="Customer Agent")]
        public Agent? Agent { get; set; }
        [Display(Name="Photo")]
        public string PhotoPath { get; set; }

    }
}
