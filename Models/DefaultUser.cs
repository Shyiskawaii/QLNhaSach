using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace QLNhaSach.Models
{
    public class DefaultUser : IdentityUser
    {
        [PersonalData]
        [Required]
        public string RealName { get; set; }

        [PersonalData]
        [Required]
        public string UserName { get; set; }

        [PersonalData]
        public string Address { get; set; }


        [PersonalData]
        [DataType(DataType.Date)]
        public DateTime UserCreationDate { get; set; } = DateTime.Now;
    }
}
