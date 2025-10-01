using BodyUpAPI.Dtos;
using BodyUpAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BodyUpAPI.Controllers;

[Route("api/products")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<List<ProductDto>>> GetAllProducts()
    {
        var result = await _productService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ProductDto>> GetAllProduct(int id)
    {
        var result = await _productService.GetAsync(id);
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
}
