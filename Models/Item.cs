using System.ComponentModel.DataAnnotations.Schema;
namespace temu_back.Models
{
    public class Item
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public required decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
    