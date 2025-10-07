using ProteinProAPI.Dtos;

namespace ProteinProAPI.Services.Interfaces;

public interface ISubCategoryService
{
    Task<List<SubCategoryDto>> GetAllAsync();
    Task<SubCategoryDto> GetAsync(int id);
    Task<List<SubCategoryDto>> GetAllByCategoryIdAsync(int categoryId);
}
