using BodyUpAPI.Database;
using BodyUpAPI.Models;
using BodyUpAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BodyUpAPI.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ProductRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Product>> GetAllAsync()
    {
        return await _dbContext.Products.AsNoTracking().ToListAsync();
    }

    public async Task<Product?> GetAsync(int id)
    {
        return await _dbContext.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<List<Product>> GetAllByCategoryIdAsync(int categoryId)
    {
        return await _dbContext.ProductSubCategories
            .AsNoTracking()
            .Where(psc => psc.SubCategory.SubCategoryCategories
                .Any(scc => scc.CategoryId == categoryId))
            .Select(psc => psc.Product)
            .Distinct()
            .ToListAsync();
    }

    public async Task<List<Product>> GetAllBySubCategoryIdAsync(int subCategoryId)
    {
        return await _dbContext.ProductSubCategories
        .AsNoTracking()
        .Where(psc => psc.SubCategoryId == subCategoryId)
        .Select(psc => psc.Product)
        .Distinct()
        .ToListAsync();
    }
}
