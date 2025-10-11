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
        int? subCategoryId,
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

        if (subCategoryId.HasValue)
        {
            query = _dbContext.ProductSubCategories
                .AsNoTracking()
                .Where(psc => psc.SubCategoryId == subCategoryId.Value)
                .Select(psc => psc.Product)
                .Distinct();
        }
        else if (categoryId.HasValue)
        {
            query = _dbContext.ProductSubCategories
                .AsNoTracking()
                .Where(psc => psc.SubCategory.SubCategoryCategories
                    .Any(scc => scc.CategoryId == categoryId.Value))
                .Select(psc => psc.Product)
                .Distinct();
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
}
