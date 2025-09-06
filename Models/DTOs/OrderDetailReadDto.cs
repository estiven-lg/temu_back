namespace temu_back.Models.DTOs
{
	public class OrderDetailReadDto
	{
		public int Id { get; set; }
		public int OrderId { get; set; }
		public int ItemId { get; set; }
		public ItemReadDto Item { get; set; } = null!;
		public int Quantity { get; set; }
		public decimal Price { get; set; }
		public decimal Total { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime? UpdatedAt { get; set; }
	}
}
