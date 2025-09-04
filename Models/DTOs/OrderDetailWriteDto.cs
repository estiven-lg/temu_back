namespace temu_back.Models.DTOs
{
	public class OrderDetailWriteDto
	{
		public int OrderId { get; set; }
		public int ItemId { get; set; }
		public int Quantity { get; set; }
		public decimal Price { get; set; }
		public decimal Total { get; set; }
	}
}
