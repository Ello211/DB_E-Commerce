using MediatR;
using DB_ECommerce.Models;
using System.Collections.Generic;

namespace DB_E_Commerce.E_Commerce.Application.Products_Categories
{
    public class GetProductsCategoriesQuery : IRequest<List<Product_Category>>
    {
    }
}
