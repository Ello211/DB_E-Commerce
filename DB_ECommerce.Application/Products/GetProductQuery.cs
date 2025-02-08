using MediatR;
using DB_ECommerce.Models;

namespace DB_ECommerce.Application.Products
{
    public class GetProductQuery : IRequest<Product>
    {
        public int ProductID { get; set; }
    }
}