namespace NewComputerShop.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime CreatedDate { get; set; }

        // public decimal Total { get; set; }
        public bool Paid { get; set; }

        public List<Orderline> Orderlines { get; set; }

        public Order()
        {
            Id = 0;
            UserId = default; // 0 
            Paid = default; // false
            Orderlines = default; // null
        }
    }
}
