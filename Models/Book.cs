using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QLNhaSach.Models
{
    public class Book
    {
        public int BookId { get; set; }

        [Required]
        [MaxLength(50)]
        public string BookName { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        [MaxLength(30)]
        public string Author { get; set; }
        
        [Required]
        [MaxLength(30)]
        public string Language { get; set; }

        [Required]
        [MaxLength(30)]
        public string Publisher { get; set; }
        
        [Required]
        public bool BookStatus { get; set; }
        
        [Required,
        DataType(DataType.Currency),
        DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]
        
        public int Price { get; set; }

        [Required]
        public int NumOfBook { get; set; }

        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; }



    }
}
