using ProteinProAPI.Dtos;
using ProteinProAPI.Models;

namespace ProteinProAPI.Mappers;

public static class SubCategoryMapper
{
    public static SubCategoryDto MapToDto(SubCategory subCategory)
    {
        return new SubCategoryDto
        {
            Id = subCategory.Id,
            Name = subCategory.Name,
            Url = subCategory.Url,
            Keywords = subCategory.Keywords,
            Description = subCategory.Description,
        };
    }
}
