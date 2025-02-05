using MediatR;
using DB_E_Commerce.E_Commerce.Models;

namespace DB_E_Commerce.E_Commerce.Application.Products
{
    public class GetProductQuery : IRequest<Product>
    {
        public int Id { get; set; }
    }
}