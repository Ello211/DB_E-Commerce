﻿using MediatR;

namespace DB_ECommerce.Application.Orders
{
    public class CreateOrderCommand : IRequest
    {
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public int CustomerID { get; set; }
    }
}