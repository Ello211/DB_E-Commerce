﻿using MediatR;

using DB_ECommerce.Models;

namespace DB_ECommerce.Application.Customers;
public class UpdateCustomerCommand : IRequest
{
    public int CustomerID { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Address { get; set; }

    public DateOnly? Birthday { get; set; }

    public DateOnly AccountCreated { get; set; }

    public string Email { get; set; }

    public Customer ToCustomer()
    {
        var customer = new Customer
        {
            CustomerID = this.CustomerID, 
            FirstName = this.FirstName,
            LastName = this.LastName,
            Address = this.Address,
            Birthday = this.Birthday,
            AccountCreated = this.AccountCreated,
            Email = this.Email
        };

        return customer;
    }
}

