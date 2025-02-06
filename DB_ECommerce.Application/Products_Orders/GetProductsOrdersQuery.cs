﻿using MediatR;

using DB_ECommerce.Models;

namespace DB_ECommerce.Application.Product_Orders
{
    public class GetProductsOrdersQuery : IRequest<List<Product_Order>>
    {
    }
}
