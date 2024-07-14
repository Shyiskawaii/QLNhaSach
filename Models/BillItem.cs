namespace QLNhaSach.Models
{
    public class BillItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }

        public int BillId { get; set; }
        public int BookId { get; set; }
        public Bill Bill { get; set; }
        public Book Book { get; set; }
    }
}
