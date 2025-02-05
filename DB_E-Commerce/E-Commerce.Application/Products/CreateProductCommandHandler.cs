using MediatR;
using DB_E_Commerce.E_Commerce.Application.Products;
using DB_E_Commerce.E_Commerce.Persistence;

namespace DB_E_Commerce.E_Commerce.Application.Products
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly ECommerceContext context;

        public CreateProductCommandHandler(ECommerceContext context)
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
