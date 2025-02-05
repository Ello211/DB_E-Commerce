using MediatR;

using DB_ECommerce.Models;

namespace DB_ECommerce.Application.Products;

public class CreateProductCommand : IRequest
{
    public string ProductName { get; set; }

    public decimal Price { get; set; }

    public Product ToProduct()
    {
        var product = new Product
        {
            ProductName = this.ProductName,
            Price = this.Price,

        };

        return product;
    }
}