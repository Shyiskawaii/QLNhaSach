using System.ComponentModel.DataAnnotations;

namespace QLNhaSach.ViewModels
{
    public class AddRoleViewModel
    {
        [Required]
        [Display(Name = "Role")]
        public string RoleName { get; set; }
    }
}
