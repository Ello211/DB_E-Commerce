using MediatR;
using DB_ECommerce.Application.Products;
using DB_ECommerce.Persistence;

namespace DB_E_Commerce.E_Commerce.Application.Products
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly DB_ECommerceContext context;

        public CreateProductCommandHandler(DB_ECommerceContext context)
        {
            this.context = context;
        }

        public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = request.ToProduct();

            context.Products.Add(product);

            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
