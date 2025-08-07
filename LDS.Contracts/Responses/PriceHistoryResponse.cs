namespace LDS.Contracts.Responses
{
	public class PriceHistoryResponse
	{
		public int Id { get; set; }

		public int ProductId { get; set; }

		public decimal Price { get; set; }

		public DateOnly StartDate { get; set; }
	}
}
