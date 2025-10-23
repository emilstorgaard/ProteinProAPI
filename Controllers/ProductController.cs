using Microsoft.AspNetCore.Mvc;
using ProteinProAPI.Dtos;
using ProteinProAPI.Services.Interfaces;

namespace ProteinProAPI.Controllers;

[Route("api/products")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    private const int PageSize = 20;

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
    public async Task<IActionResult> GetProducts(
        [FromQuery] int? categoryId,
        [FromQuery] int page = 1,
        [FromQuery] string sort = "",
        [FromQuery] decimal? minPrice = null,
        [FromQuery] decimal? maxPrice = null,
        [FromQuery] string? brand = null,
        [FromQuery] string? retailer = null,
        [FromQuery] string? search = null)
    {
        var (totalProducts, totalPages, products) = await _productService.GetProductsAsync(
            categoryId,
            page,
            PageSize,
            sort,
            minPrice,
            maxPrice,
            brand,
            retailer,
            search
        );

        var result = new
        {
            CategoryId = categoryId,
            TotalProducts = totalProducts,
            TotalPages = totalPages,
            CurrentPage = page,
            PageSize,
            Products = products
        };

        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ProductDto>> GetProduct(int id)
    {
        var result = await _productService.GetAsync(id);
        return Ok(result);
    }

    [HttpGet("retailers")]
    public async Task<IActionResult> GetRetailers([FromQuery] int? categoryId)
    {
        var result = await _productService.GetRetailersAsync(categoryId);
        return Ok(result);
    }

    [HttpGet("brands")]
    public async Task<IActionResult> GetBrands([FromQuery] int? categoryId)
    {
        var result = await _productService.GetBrandsAsync(categoryId);
        return Ok(result);
    }
}
