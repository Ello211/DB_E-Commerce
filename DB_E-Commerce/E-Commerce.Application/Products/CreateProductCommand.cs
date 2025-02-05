﻿using MediatR;
using DB_E_Commerce.E_Commerce.Models;

namespace DB_E_Commerce.E_Commerce.Application.Products
{
    public class CreateProductCommand : IRequest
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public List<ProductCategory> ProductCategories { get; set; } = new();

        public Product ToProduct()
        {
            var product = new Product
            {
                ProductName = this.ProductName,
                Price = this.Price
            };
            return product;
        }
    }
}
