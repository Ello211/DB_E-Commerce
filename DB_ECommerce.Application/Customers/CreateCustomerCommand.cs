using MediatR;

using DB_ECommerce.Models;

namespace DB_ECommerce.Application.Customers;

public class CreateCustomerCommand : IRequest
{
    public string Firstname { get; set; }

    public string Lastname { get; set; }

    public string Address { get; set; }

    public DateOnly? Birthday { get; set; }

    public string Email { get; set; }

    public Customer ToCustomer()
    {
        var customer = new Customer
        {
            Firstname = this.Firstname,
            Lastname = this.Lastname,
            Address = this.Address,
            Birthday = this.Birthday,
            AccountCreated = DateOnly.FromDateTime(DateTime.UtcNow),
            Email = this.Email
        };

        return customer;
    }
}

