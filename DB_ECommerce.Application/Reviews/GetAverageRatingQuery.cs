using MediatR;

namespace DB_ECommerce.Application.Reviews
{
    public class GetAverageRatingQuery : IRequest<double?>
    {
        public string ProductId { get; set; }

        public GetAverageRatingQuery(string productId)
        {
            ProductId = productId;
        }
    }
}
