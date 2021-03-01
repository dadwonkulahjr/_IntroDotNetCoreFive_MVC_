using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DotNetCoreFive_MVC_Project.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        [DisplayName(displayName:"Role Name")]
        public string RoleName { get; set; }
    }
}
