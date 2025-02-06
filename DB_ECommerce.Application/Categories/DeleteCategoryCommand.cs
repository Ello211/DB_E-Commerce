using MediatR;

namespace DB_ECommerce.Application.Categories
{
    public class DeleteCategoryCommand : IRequest
    {
        public int CategoryID { get; set; }
    }
}
