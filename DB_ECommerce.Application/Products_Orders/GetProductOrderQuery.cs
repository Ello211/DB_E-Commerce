using MediatR;
using Microsoft.EntityFrameworkCore;
using DB_ECommerce.Models;
using DB_ECommerce.Persistence;

namespace DB_E_Commerce.E_Commerce.Application.Product_Orders
{
    public class GetProductOrderQuery : IRequest<Product_Order>
    {
        public int ProductId { get; set; }
        public int OrderId { get; set; }
    }
}
