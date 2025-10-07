using ProteinProAPI.Dtos;
using ProteinProAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ProteinProAPI.Controllers;

[Route("api/products")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("all")]
    public async Task<ActionResult<List<ProductDto>>> GetAllProducts()
    {
        var result = await _productService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProductsByPage(int page = 1, string sort = "", decimal? minPrice = null, decimal? maxPrice = null, string? brand = null, string? retailer = null, string? search = null)
    {
        const int pageSize = 20;
        var (totalProducts, totalPages, products) = await _productService.GetProductsByPageSortAndFilterAsync(page, pageSize, sort, minPrice, maxPrice, brand, retailer, search);

        var result = new
        {
            TotalProducts = totalProducts,
            TotalPages = totalPages,
            CurrentPage = page,
            PageSize = pageSize,
            Products = products
        };

        return Ok(result);
    }

    [HttpGet("category/{categoryId:int}")]
    public async Task<ActionResult<List<ProductDto>>> GetAllProductsByCategoryId(int categoryId)
    {
        var result = await _productService.GetAllByCategoryIdAsync(categoryId);
        return Ok(result);
    }

    [HttpGet("subcategory/{subCategoryId:int}")]
    public async Task<ActionResult<List<ProductDto>>> GetAllProductsBysUBCategoryId(int subCategoryId)
    {
        var result = await _productService.GetAllBySubCategoryIdAsync(subCategoryId);
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ProductDto>> GetProduct(int id)
    {
        var result = await _productService.GetAsync(id);
        return Ok(result);
    }
}
