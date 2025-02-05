using MediatR;
using DB_E_Commerce.E_Commerce.Models;

namespace DB_E_Commerce.E_Commerce.Application.Products
{
    public class UpdateProductCommand : IRequest
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public List<ProductCategory> ProductCategories { get; set; } = new();

        public Product ToProduct()
        {
            var product = new Product
            {
                ProductID = this.Id,
                ProductName = this.ProductName,
                Price = this.Price
            };
            return product;
        }
    }
}