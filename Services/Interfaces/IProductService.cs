using ProteinProAPI.Dtos;
using ProteinProAPI.Models;

namespace ProteinProAPI.Services.Interfaces;

public interface IProductService
{
    Task<List<ProductDto>> GetAllAsync();
    Task<(int TotalProducts, int TotalPages, List<ProductDto> Products)> GetProductsByPageSortAndFilterAsync(int page, int pageSize, string sort, decimal? minPrice, decimal? maxPrice, string? brand, string? retailer, string? search);
    Task<ProductDto> GetAsync(int id);
    Task<List<ProductDto>> GetAllByCategoryIdAsync(int categoryId);
    Task<List<ProductDto>> GetAllBySubCategoryIdAsync(int subCategoryId);
}
