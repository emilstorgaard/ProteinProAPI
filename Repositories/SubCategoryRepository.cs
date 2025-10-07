using ProteinProAPI.Database;
using ProteinProAPI.Models;
using ProteinProAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ProteinProAPI.Repositories;

public class SubCategoryRepository : ISubCategoryRepository
{
    private readonly ApplicationDbContext _dbContext;

    public SubCategoryRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<SubCategory>> GetAllAsync()
    {
        return await _dbContext.SubCategories.AsNoTracking().ToListAsync();
    }

    public async Task<SubCategory?> GetAsync(int id)
    {
        return await _dbContext.SubCategories.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<List<SubCategory>> GetAllByCategoryIdAsync(int categoryId)
    {
        return await _dbContext.SubCategoryCategories
        .AsNoTracking()
        .Where(scc => scc.CategoryId == categoryId)
        .Select(scc => scc.SubCategory)
        .Distinct()
        .ToListAsync();
    }
}
