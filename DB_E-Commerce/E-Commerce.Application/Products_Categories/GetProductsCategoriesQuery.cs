using MediatR;
using DB_E_Commerce.E_Commerce.Models;
using System.Collections.Generic;

namespace DB_E_Commerce.E_Commerce.Application.Products_Categories
{
    public class GetProductsCategoriesQuery : IRequest<List<ProductCategory>>
    {
    }
}
