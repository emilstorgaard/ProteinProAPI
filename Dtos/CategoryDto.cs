namespace ProteinProAPI.Dtos;

public class CategoryDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Url { get; set; }
    public required string Description { get; set; }
    public List<SubCategoryDto> SubCategories { get; set; } = new List<SubCategoryDto>();
}
