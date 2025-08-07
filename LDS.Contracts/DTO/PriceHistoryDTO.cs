namespace LDS.Contracts.DTO
{
	public class PriceHistoryDTO
	{
		public int Id { get; set; }

		public int ProductId { get; set; }

		public decimal Price { get; set; }

		public DateOnly StartDate { get; set; }
	}
}
