using BodyUpAPI.Dtos;
using BodyUpAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BodyUpAPI.Controllers;

[Route("api/categories")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<ActionResult<List<CategoryDto>>> GetAllCategories()
    {
        var result = await _categoryService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CategoryDto>> GetCategory(int id)
    {
        var result = await _categoryService.GetAsync(id);
        return Ok(result);
    }
}
