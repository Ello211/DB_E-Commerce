using MediatR;

namespace DB_E_Commerce.E_Commerce.Application.Products_Categories
{
    public class UpdateProductCategoryCommand : IRequest
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
    }
}
