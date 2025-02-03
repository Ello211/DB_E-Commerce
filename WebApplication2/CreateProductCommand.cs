using MediatR;

using DB_E_Commerce.Models;

namespace DB_E_Commerce.Application.Products;

public class CreateProductCommand : IRequest
{
    public string Productname { get; set; }

    public decimal Price { get; set; }

    public Product ToProduct()
    {
        var product = new Product
        {
            Productname = this.Productname,
            Price = this.Price,
            FirstName = this.FirstName,

        };

        return product;
    }
}