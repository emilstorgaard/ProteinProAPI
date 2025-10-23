using ProteinProAPI.Dtos;
using ProteinProAPI.Models;

namespace ProteinProAPI.Mappers;

public static class CategoryMapper
{
    public static CategoryDto MapToDto(Category category)
    {
        return new CategoryDto
        {
            Id = category.Id,
            Name = category.Name,
            Keywords = category.Keywords
        };
    }
}
