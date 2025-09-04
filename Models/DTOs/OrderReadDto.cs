namespace temu_back.Models.DTOs
{
	public class OrderReadDto
	{
		public int Id { get; set; }
		public int PersonId { get; set; }
		public int Number { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime? UpdatedAt { get; set; }
	}
}
