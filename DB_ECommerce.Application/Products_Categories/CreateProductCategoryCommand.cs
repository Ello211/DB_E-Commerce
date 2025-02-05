using MediatR;
using Microsoft.EntityFrameworkCore;
using DB_ECommerce.Models;
using DB_ECommerce.Persistence;

namespace DB_E_Commerce.E_Commerce.Application.Products_Categories
{
    public class CreateProductCategoryCommand : IRequest
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
    }
}
