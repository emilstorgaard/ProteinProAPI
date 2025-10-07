namespace ProteinProAPI.Dtos;

public class ProductDto
{
    public int Id { get; set; }
    public required string ExternalProductId { get; set; }
    public required string Retailer { get; set; }
    public required string Brand { get; set; }
    public required string Name { get; set; }
    public required string Price { get; set; }
    public required string Description { get; set; }
    public required string Image { get; set; }
    public required string Url { get; set; }
}
