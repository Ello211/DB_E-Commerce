using MediatR;

namespace DB_E_Commerce.Application.Categories
{
    public class DeleteCategoryCommand : IRequest
    {
        public int Id { get; set; }
    }
}
