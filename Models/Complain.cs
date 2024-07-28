using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QLNhaSach.Models
{
    public class Complain
    {
        public int ComplainId { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        [DefaultValue(false)]
        public bool Status { get; set; }
        [DefaultValue(false)]
        public bool Response { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
