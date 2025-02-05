using MediatR;
using DB_E_Commerce.E_Commerce.Application.Categories;
using DB_ECommerce.Persistence;

namespace DB_E_Commerce.Application.Categories
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Unit>
    {
        private readonly DB_ECommerceContext context;

        public CreateCategoryCommandHandler(DB_ECommerceContext context)
        {
            this.context = context;
        }

        public async Task<Unit> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = request.ToCategory();
            context.Categories.Add(category);

            await context.SaveChangesAsync(cancellationToken);

            return Unit.Value; 
        }
    }
}
