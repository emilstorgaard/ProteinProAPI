using BodyUpAPI.Models;

namespace BodyUpAPI.Repositories.Interfaces;

public interface ICategoryRepository
{
    Task<List<Category>> GetAllAsync();
    Task<Category?> GetAsync(int id);
}
