using System.ComponentModel.DataAnnotations.Schema;
namespace temu_back.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public required int OrderId { get; set; }
        public Order Order { get; set; } = new Order
        {
            PersonId = 0,
        };
        public required int ItemId { get; set; }
        public Item Item { get; set; } = new Item
        {
            Name = string.Empty,
            Price = 0
        };
        public int Quantity { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public required decimal Price { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public required decimal Total { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
