using DB_ECommerce.Persistence.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DB_ECommerce.Application.Reviews
{
    public class GetAverageRatingHandler : IRequestHandler<GetAverageRatingQuery, double?>
    {
        private readonly ReviewRepository _reviewRepository;

        public GetAverageRatingHandler(ReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<double?> Handle(GetAverageRatingQuery request, CancellationToken cancellationToken)
        {
            return await _reviewRepository.GetAverageRatingAsync(request.ProductId);
        }
    }
}
