namespace ProteinProAPI.Models;

public class SubCategoryCategories
{
    public int SubCategoryId { get; set; }
    public int CategoryId { get; set; }
    public SubCategory SubCategory { get; set; } = null!;
    public Category Category { get; set; } = null!;
}
