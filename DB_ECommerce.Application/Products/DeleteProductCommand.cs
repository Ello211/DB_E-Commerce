using MediatR;

namespace DB_ECommerce.Application.Products
{
    public class DeleteProductCommand : IRequest
    {
        public int ProductID { get; set; }
    }
}
