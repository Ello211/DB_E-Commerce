using MediatR;

using DB_ECommerce.Persistence;

namespace DB_ECommerce.Application.Categories
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand>
    {
        private readonly DB_ECommerceContext context;

        public CreateCategoryCommandHandler(DB_ECommerceContext context)
        {
            this.context = context;
        }

        public async Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = request.ToCategory();
            context.Categories.Add(category);

            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
