using ProteinProAPI.Dtos;
using ProteinProAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ProteinProAPI.Controllers;

[Route("api/subcategories")]
[ApiController]
public class SubCategoryController : ControllerBase
{
    private readonly ISubCategoryService _subCategoryService;

    public SubCategoryController(ISubCategoryService subCategoryService)
    {
        _subCategoryService = subCategoryService;
    }

    [HttpGet]
    public async Task<ActionResult<List<SubCategoryDto>>> GetAllSubCategories()
    {
        var result = await _subCategoryService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<List<SubCategoryDto>>> GetSubCategorie(int id)
    {
        var result = await _subCategoryService.GetAsync(id);
        return Ok(result);
    }

    [HttpGet("category/{categoryId:int}")]
    public async Task<ActionResult<List<SubCategoryDto>>> GetAllByCategoryId(int categoryId)
    {
        var result = await _subCategoryService.GetAllByCategoryIdAsync(categoryId);
        return Ok(result);
    }
}
