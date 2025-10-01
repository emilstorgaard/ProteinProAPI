using BodyUpAPI.Database;
using BodyUpAPI.Models;
using BodyUpAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BodyUpAPI.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _dbContext;

    public CategoryRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Category>> GetAllAsync()
    {
        return await _dbContext.Categories
        .Include(c => c.SubCategoryCategories)
            .ThenInclude(sc => sc.SubCategory)
        .AsNoTracking()
        .ToListAsync();
    }

    public async Task<Category?> GetAsync(int id)
    {
        return await _dbContext.Categories
        .Include(c => c.SubCategoryCategories)
            .ThenInclude(sc => sc.SubCategory)
        .AsNoTracking()
        .FirstOrDefaultAsync(c => c.Id == id);
    }
}
