using Microsoft.EntityFrameworkCore;
using ProteinProAPI.Database;
using ProteinProAPI.Models;
using ProteinProAPI.Repositories.Interfaces;

namespace ProteinProAPI.Repositories;

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

    public async Task<(int TotalProducts, int TotalPages, List<Product> Products)> GetProductsAsync(
        int? categoryId,
        int page,
        int pageSize,
        string? sort,
        decimal? minPrice,
        decimal? maxPrice,
        string? brand,
        string? retailer,
        string? search)
    {
        if (page <= 0) page = 1;

        IQueryable<Product> query;

        if (categoryId.HasValue)
        {
            query = _dbContext.Products.AsNoTracking().Where(p => p.CategoryId == categoryId).Distinct();
        }

        else
        {
            query = _dbContext.Products.AsQueryable();
        }

        if (minPrice.HasValue)
            query = query.Where(p => Convert.ToDecimal(p.Price) >= minPrice.Value);

        if (maxPrice.HasValue)
            query = query.Where(p => Convert.ToDecimal(p.Price) <= maxPrice.Value);

        if (!string.IsNullOrWhiteSpace(brand))
            query = query.Where(p => p.Brand == brand);

        if (!string.IsNullOrWhiteSpace(retailer))
            query = query.Where(p => p.Retailer == retailer);

        if (!string.IsNullOrWhiteSpace(search))
        {
            search = search.ToLower();
            query = query.Where(p =>
                p.Name.ToLower().Contains(search) ||
                p.Description.ToLower().Contains(search) ||
                p.Brand.ToLower().Contains(search) ||
                p.Retailer.ToLower().Contains(search));
        }

        query = sort?.ToLower() switch
        {
            "price-low" => query.OrderBy(p => Convert.ToDecimal(p.Price)),
            "price-high" => query.OrderByDescending(p => Convert.ToDecimal(p.Price)),
            _ => query.OrderBy(p => p.Id)
        };

        var totalProducts = await query.CountAsync();
        var totalPages = totalProducts > 0
            ? (int)Math.Ceiling(totalProducts / (double)pageSize)
            : 1;

        var products = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (totalProducts, totalPages, products);
    }

    public async Task<Product?> GetAsync(int id)
    {
        return await _dbContext.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<List<string>> GetRetailersAsync(int? categoryId)
    {
        IQueryable<Product> query = _dbContext.Products.AsNoTracking();

        if (categoryId.HasValue)
            query = query.Where(p => p.CategoryId == categoryId.Value);

        return await query
            .Select(p => p.Retailer)
            .Where(r => !string.IsNullOrEmpty(r))
            .Distinct()
            .OrderBy(r => r)
            .ToListAsync();
    }

    public async Task<List<string>> GetBrandsAsync(int? categoryId)
    {
        IQueryable<Product> query = _dbContext.Products.AsNoTracking();

        if (categoryId.HasValue)
            query = query.Where(p => p.CategoryId == categoryId.Value);

        return await query
            .Select(p => p.Brand)
            .Where(b => !string.IsNullOrEmpty(b))
            .Distinct()
            .OrderBy(b => b)
            .ToListAsync();
    }
}
