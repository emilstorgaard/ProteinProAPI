namespace ProteinProAPI.Models;

public class Category
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Keywords { get; set; }

    public ICollection<Product> Products { get; set; } = new List<Product>();
}
