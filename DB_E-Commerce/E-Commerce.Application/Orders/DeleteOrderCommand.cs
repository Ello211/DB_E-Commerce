using MediatR;

namespace DB_E_Commerce.E_Commerce.Application.Orderss
{
    public class DeleteOrderCommand : IRequest
    {
        public int Id { get; set; }
    }
}
