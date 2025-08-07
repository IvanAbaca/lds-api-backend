using LDS.Contracts.DTO;

namespace LDS.Domain.Services.Interfaces
{
	public interface ICategoryService
	{
		Task<List<CategoryDTO>> GetAllAsync();
		Task<CategoryDTO?> GetByIdAsync(int id);
		Task<CategoryDTO> CreateAsync(CategoryDTO dto);
		Task<CategoryDTO?> UpdateAsync(CategoryDTO dto);
		Task<bool> DeleteAsync(int id);
	}
}
