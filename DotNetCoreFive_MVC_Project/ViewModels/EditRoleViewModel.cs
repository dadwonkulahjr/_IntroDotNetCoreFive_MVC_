using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DotNetCoreFive_MVC_Project.ViewModels
{
    public class EditRoleViewModel
    {
        public EditRoleViewModel()
        {
            Users = new List<string>();
        }
        [DisplayName(displayName: "Role Id")]
        public string RoleId { get; set; }
        [DisplayName(displayName: "Role Name")]
        [Required]
        public string RoleName { get; set; }
        public List<string> Users { get; set; }
    }
}
