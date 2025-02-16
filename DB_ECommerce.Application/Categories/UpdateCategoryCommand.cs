using MediatR;

namespace DB_ECommerce.Application.Categories
{
    public class UpdateCategoryCommand : IRequest
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

    }
}
