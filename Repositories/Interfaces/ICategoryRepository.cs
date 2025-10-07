using ProteinProAPI.Models;

namespace ProteinProAPI.Repositories.Interfaces;

public interface ICategoryRepository
{
    Task<List<Category>> GetAllAsync();
    Task<Category?> GetAsync(int id);
}
