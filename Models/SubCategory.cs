namespace BodyUpAPI.Models;

public class SubCategory
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Url { get; set; }
    public required string Keywords { get; set; }
    public required string Description { get; set; }

    public ICollection<ProductSubCategories> ProductSubCategories { get; set; } = new List<ProductSubCategories>();
    public ICollection<SubCategoryCategories> SubCategoryCategories { get; set; } = new List<SubCategoryCategories>();
}
