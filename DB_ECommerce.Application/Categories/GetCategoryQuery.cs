using MediatR;
using DB_ECommerce.Models;

namespace DB_ECommerce.Application.Categories
{
    public class GetCategoryQuery : IRequest<Category>
    {
        public int CategoryID { get; set; }
    }
}


