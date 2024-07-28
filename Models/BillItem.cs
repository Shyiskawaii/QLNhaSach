using System.ComponentModel.DataAnnotations;

namespace QLNhaSach.Models
{
    public class BillItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        [DataType(DataType.Currency),
        DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]
        public int Price { get; set; }

        public int BillId { get; set; }
        public int BookId { get; set; }
        public Bill Bill { get; set; }
        public Book Book { get; set; }
    }
}
