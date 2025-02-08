using MediatR;
using DB_ECommerce.Persistence;

namespace DB_ECommerce.Application.Categories
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly DB_ECommerceContext context;

        public DeleteCategoryCommandHandler(DB_ECommerceContext context)
        {
            this.context = context;
        }

        public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await context.Categories.FindAsync(new object[] { request.CategoryID }, cancellationToken);
            if (category == null)
            {
                throw new KeyNotFoundException($"Category with CategoryID {request.CategoryID} not found.");
            }

            context.Categories.Remove(category);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
