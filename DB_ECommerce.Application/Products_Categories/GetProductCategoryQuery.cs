using MediatR;
using DB_ECommerce.Models;

namespace DB_E_Commerce.E_Commerce.Application.Products_Categories
{
    public class GetProductCategoryQuery : IRequest<Product_Category>
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
    }
}
