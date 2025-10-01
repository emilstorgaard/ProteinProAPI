using BodyUpAPI.Dtos;
using BodyUpAPI.Mappers;
using BodyUpAPI.Repositories.Interfaces;
using BodyUpAPI.Services.Interfaces;

namespace BodyUpAPI.Services;

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

    public async Task<ProductDto> GetAsync(int id)
    {
        var product = await _productRepository.GetAsync(id);
        return ProductMapper.MapToDto(product);
    }

    public async Task<List<ProductDto>> GetAllByCategoryIdAsync(int categoryId)
    {
        var products = await _productRepository.GetAllByCategoryIdAsync(categoryId);
        return products.Select(product => ProductMapper.MapToDto(product)).ToList();
    }

    public async Task<List<ProductDto>> GetAllBySubCategoryIdAsync(int subCategoryId)
    {
        var products = await _productRepository.GetAllBySubCategoryIdAsync(subCategoryId);
        return products.Select(product => ProductMapper.MapToDto(product)).ToList();
    }
}
