using ProteinProAPI.Models;

namespace ProteinProAPI.Repositories.Interfaces;

public interface ISubCategoryRepository
{
    Task<List<SubCategory>> GetAllAsync();
    Task<SubCategory?> GetAsync(int id);
    Task<List<SubCategory>> GetAllByCategoryIdAsync(int categoryId);
}
