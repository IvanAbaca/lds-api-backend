namespace LDS.Contracts.Requests
{
	public class UpdatePriceHistoryRequest
	{
		public int ProductId { get; set; }

		public decimal Price { get; set; }
	}
}