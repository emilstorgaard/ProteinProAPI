using ProteinProAPI.Dtos;
using ProteinProAPI.Mappers;
using ProteinProAPI.Repositories.Interfaces;
using ProteinProAPI.Services.Interfaces;

namespace ProteinProAPI.Services;

public class ProductsService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductsService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<List<ProductDto>> GetAllAsync()
    {
        var products = await _productRepository.GetAllAsync();
        return products.Select(product => ProductMapper.MapToDto(product)).ToList();
    }

    public async Task<(int TotalProducts, int TotalPages, List<ProductDto> Products)> GetProductsAsync(int? categoryId, int? subCategoryId, int page, int pageSize, string? sort, decimal? minPrice, decimal? maxPrice, string? brand, string? retailer, string? search)
    {
        var (totalProducts, totalPages, products) = await _productRepository.GetProductsAsync(
            categoryId,
            subCategoryId,
            page,
            pageSize,
            sort,
            minPrice,
            maxPrice,
            brand,
            retailer,
            search
        );

        var productDtos = products.Select(ProductMapper.MapToDto).ToList();

        return (totalProducts, totalPages, productDtos);
    }

    public async Task<ProductDto> GetAsync(int id)
    {
        var product = await _productRepository.GetAsync(id);
        return ProductMapper.MapToDto(product);
    }
}
