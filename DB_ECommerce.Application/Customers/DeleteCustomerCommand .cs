using MediatR;

namespace DB_ECommerce.Application.Customers;

public class DeleteCustomerCommand : IRequest
{
    public int CustomerID { get; set; }
}