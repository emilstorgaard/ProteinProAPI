namespace ProteinProAPI.Dtos;

public class SubCategoryDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Url { get; set; }
    public required string Keywords { get; set; }
    public required string Description { get; set; }
}
