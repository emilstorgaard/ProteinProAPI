using ProteinProAPI.Dtos;

namespace ProteinProAPI.Services.Interfaces;

public interface IProductService
{
    Task<List<ProductDto>> GetAllAsync();
    Task<(int TotalProducts, int TotalPages, List<ProductDto> Products)> GetProductsAsync(int? categoryId, int page, int pageSize, string? sort, decimal? minPrice, decimal? maxPrice, string? brand, string? retailer, string? search);
    Task<ProductDto> GetAsync(int id);
    Task<List<string>> GetRetailersAsync(int? categoryId);
    Task<List<string>> GetBrandsAsync(int? categoryId);

}
