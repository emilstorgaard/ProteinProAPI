using BodyUpAPI.Dtos;
using BodyUpAPI.Models;

namespace BodyUpAPI.Mappers;

public static class CategoryMapper
{
    public static CategoryDto MapToDto(Category category)
    {
        return new CategoryDto
        {
            Id = category.Id,
            Name = category.Name,
            Url = category.Url,
            Description = category.Description,
            SubCategories = category.SubCategoryCategories
                .Select(sc => SubCategoryMapper.MapToDto(sc.SubCategory))
                .ToList()
        };
    }
}
