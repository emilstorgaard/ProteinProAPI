namespace ProteinProAPI.Models;

public class Product
{
    public int Id { get; set; }
    public required string ExternalProductId { get; set; }
    public required string Retailer { get; set; }
    public required string Brand { get; set; }
    public required string Name { get; set; }
    public required string Price { get; set; }
    public required string OriginalPrice { get; set; }
    public required string Description { get; set; }
    public required string Image { get; set; }
    public required string Url { get; set; }
    public int CategoryId { get; set; }

    public Category Category { get; set; } = null!;
}
