namespace temu_back.Models
{
    public class Order
    {
        public int Id { get; set; }
        public required int PersonId { get; set; }
        public Person Person { get; set; } = null!;
        public int Number { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
