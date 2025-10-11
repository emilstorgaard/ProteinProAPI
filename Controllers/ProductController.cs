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
        [FromQuery] int? subCategoryId,
        [FromQuery] int page = 1,
        [FromQuery] string sort = "",
        [FromQuery] int test = 1,
        [FromQuery] decimal? minPrice = null,
        [FromQuery] decimal? maxPrice = null,
        [FromQuery] string? brand = null,
        [FromQuery] string? retailer = null,
        [FromQuery] string? search = null)
    {
        var (totalProducts, totalPages, products) = await _productService.GetProductsAsync(
            categoryId,
            subCategoryId,
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
            SubCategoryId = subCategoryId,
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
}
