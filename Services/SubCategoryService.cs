using BodyUpAPI.Dtos;
using BodyUpAPI.Mappers;
using BodyUpAPI.Repositories.Interfaces;
using BodyUpAPI.Services.Interfaces;

namespace BodyUpAPI.Services;

public class SubCategoryService : ISubCategoryService
{
    private readonly ISubCategoryRepository _subCategoryRepository;

    public SubCategoryService(ISubCategoryRepository subCategoryRepository)
    {
        _subCategoryRepository = subCategoryRepository;
    }

    public async Task<List<SubCategoryDto>> GetAllAsync()
    {
        var subCategories = await _subCategoryRepository.GetAllAsync();
        return subCategories.Select(subCategory => SubCategoryMapper.MapToDto(subCategory)).ToList();
    }

    public async Task<SubCategoryDto> GetAsync(int id)
    {
        var subCategory = await _subCategoryRepository.GetAsync(id);
        return SubCategoryMapper.MapToDto(subCategory);
    }

    public async Task<List<SubCategoryDto>> GetAllByCategoryIdAsync(int categoryId)
    {
        var subCategories = await _subCategoryRepository.GetAllByCategoryIdAsync(categoryId);
        return subCategories.Select(subCategory => SubCategoryMapper.MapToDto(subCategory)).ToList();
    }
}
