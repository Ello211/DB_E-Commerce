using MediatR;
using Microsoft.EntityFrameworkCore;
using DB_E_Commerce.E_Commerce.Models;
using DB_E_Commerce.E_Commerce.Persistence;

namespace DB_E_Commerce.E_Commerce.Application.Products_Categories
{
    public class CreateProductCategoryCommand : IRequest
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
    }
}
