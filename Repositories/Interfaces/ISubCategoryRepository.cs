using BodyUpAPI.Models;

namespace BodyUpAPI.Repositories.Interfaces;

public interface ISubCategoryRepository
{
    Task<List<SubCategory>> GetAllAsync();
    Task<SubCategory?> GetAsync(int id);
    Task<List<SubCategory>> GetAllByCategoryIdAsync(int categoryId);
}
