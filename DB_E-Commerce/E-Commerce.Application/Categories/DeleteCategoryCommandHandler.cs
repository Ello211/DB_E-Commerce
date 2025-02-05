using MediatR;
using DB_E_Commerce.E_Commerce.Persistence;
using DB_E_Commerce.Application.Categories;

namespace DB_E_Commerce.E_Commerce.Application.Categories
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly ECommerceContext context;

        public DeleteCategoryCommandHandler(ECommerceContext context)
        {
            this.context = context;
        }

        public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await context.Categories.FindAsync(new object[] { request.Id }, cancellationToken);
            if (category == null)
            {
                throw new KeyNotFoundException($"Category with ID {request.Id} not found.");
            }

            context.Categories.Remove(category);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
