namespace QLNhaSach.Models
{
    public class Bill
    {
        public int Id { get; set; }
        public List<BillItem> BillItems { get; set; } = new();
        public int BillTotal { get; set; }
        public DateTime BillDate { get; set; }
    }
}
