using BodyUpAPI.Models;

namespace BodyUpAPI.Repositories.Interfaces;

public interface IProductRepository
{
    Task<List<Product>> GetAllAsync();
    Task<Product?> GetAsync(int id);
    Task<List<Product>> GetAllByCategoryIdAsync(int categoryId);
    Task<List<Product>> GetAllBySubCategoryIdAsync(int subCategoryId);
}
