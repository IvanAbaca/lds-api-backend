namespace LDS.Contracts.Requests
{
	public class CreatePriceHistoryRequest
	{
		public int ProductId { get; set; }

		public decimal Price { get; set; }
	}
}
