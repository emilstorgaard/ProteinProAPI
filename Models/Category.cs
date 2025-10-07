namespace ProteinProAPI.Models;

public class Category
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Url { get; set; }
    public required string Description { get; set; }

    public ICollection<SubCategoryCategories> SubCategoryCategories { get; set; } = new List<SubCategoryCategories>();
}
