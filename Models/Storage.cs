using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QLNhaSach.Models
{
    public class Storage
    {
        public int StorageID { get; set; }
        public int BookId { get; set; }

        [Required]
        public int Transfer { get; set; }

        [Required,
        DataType(DataType.Currency)]
        public int Cost { get; set; }

        [Required]
        [MaxLength(100)]
        public string Note { get; set; }


    }
}
