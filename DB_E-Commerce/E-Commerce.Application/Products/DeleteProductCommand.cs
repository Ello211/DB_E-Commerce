using MediatR;

namespace DB_E_Commerce.E_Commerce.Application.Products
{
    public class DeleteProductCommand : IRequest
    {
        public int Id { get; set; }
    }
}
