using LDS.Contracts.DTO;

namespace LDS.Domain.Services.Interfaces
{
	public interface IProductService
	{
		Task<List<ProductDTO>> GetAllAsync();
		Task<ProductDTO?> GetByIdAsync(int id);
		Task<ProductDTO> CreateAsync(ProductDTO dto);
		Task<ProductDTO?> UpdateAsync(ProductDTO dto);
		Task<bool> DeleteAsync(int id);
	}
}
