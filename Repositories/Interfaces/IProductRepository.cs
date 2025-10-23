using ProteinProAPI.Models;

namespace ProteinProAPI.Repositories.Interfaces;

public interface IProductRepository
{
    Task<List<Product>> GetAllAsync();
    Task<(int TotalProducts, int TotalPages, List<Product> Products)> GetProductsAsync(int? categoryId, int page, int pageSize, string? sort, decimal? minPrice, decimal? maxPrice, string? brand, string? retailer, string? search);
    Task<Product?> GetAsync(int id);
    Task<List<string>> GetRetailersAsync(int? categoryId);
    Task<List<string>> GetBrandsAsync(int? categoryId);
}
