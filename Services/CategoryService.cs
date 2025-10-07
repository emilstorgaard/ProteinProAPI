using ProteinProAPI.Dtos;
using ProteinProAPI.Mappers;
using ProteinProAPI.Repositories.Interfaces;
using ProteinProAPI.Services.Interfaces;

namespace ProteinProAPI.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<List<CategoryDto>> GetAllAsync()
    {
        var categories = await _categoryRepository.GetAllAsync();
        return categories.Select(category => CategoryMapper.MapToDto(category)).ToList();
    }

    public async Task<CategoryDto> GetAsync(int id)
    {
        var category = await _categoryRepository.GetAsync(id);
        return CategoryMapper.MapToDto(category);
    }
}
