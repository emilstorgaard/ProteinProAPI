using ProteinProAPI.Database;
using ProteinProAPI.Models;
using ProteinProAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ProteinProAPI.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _dbContext;

    public CategoryRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Category>> GetAllAsync()
    {
        return await _dbContext.Categories.AsNoTracking().ToListAsync();
    }

    public async Task<Category?> GetAsync(int id)
    {
        return await _dbContext.Categories.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
    }
}
