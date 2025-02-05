using MediatR;
using DB_E_Commerce.E_Commerce.Models;

namespace DB_E_Commerce.E_Commerce.Application.Products_Categories
{
    public class GetProductCategoryQuery : IRequest<ProductCategory>
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
    }
}
