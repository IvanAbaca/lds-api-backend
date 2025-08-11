namespace LDS.Contracts.Requests
{
	public class CreateProductRequest
	{
		public string Name { get; set; }

		public int? BrandId { get; set; }

		public int? CategoryId { get; set; }

		public int? AreaId { get; set; }

		public int? UnitMeasureId { get; set; }

		public decimal? Quantity { get; set; }

		public decimal CurrentPrice { get; set; }

		public string ImageUrl { get; set; }
	}
}
