using BodyUpAPI.Dtos;

namespace BodyUpAPI.Services.Interfaces;

public interface IProductService
{
    Task<List<ProductDto>> GetAllAsync();
    Task<ProductDto> GetAsync(int id);
    Task<List<ProductDto>> GetAllByCategoryIdAsync(int categoryId);
    Task<List<ProductDto>> GetAllBySubCategoryIdAsync(int subCategoryId);
}
