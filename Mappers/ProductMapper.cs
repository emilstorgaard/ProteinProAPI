using BodyUpAPI.Dtos;
using BodyUpAPI.Models;

namespace BodyUpAPI.Mappers;

public static class ProductMapper
{
    public static ProductDto MapToDto(Product product)
    {
        return new ProductDto
        {
            Id = product.Id,
            ExternalProductId = product.ExternalProductId,
            Retailer = product.Retailer,
            Brand = product.Brand,
            Name = product.Name,
            Price = product.Price,
            Description = product.Description,
            Image = product.Image,
            Url = product.Url
        };
    }
}
