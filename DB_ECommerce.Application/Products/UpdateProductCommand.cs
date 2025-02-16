using MediatR;
using DB_ECommerce.Models;

namespace DB_ECommerce.Application.Products
{
    public class UpdateProductCommand : IRequest
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
    }
}
