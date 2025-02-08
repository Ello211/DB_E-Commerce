using MediatR;

namespace DB_ECommerce.Application.Orders
{
	public class GetOrderReferencesQuery : IRequest<OrderReferences>
	{
	}
}