using DB_ECommerce.Models;
using DB_ECommerce.Persistence.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DB_ECommerce.Application.Reviews
{
    public class GetReviewsByProductIdHandler : IRequestHandler<GetReviewsByProductIdQuery, List<Review>>
    {
        private readonly ReviewRepository _reviewRepository;

        public GetReviewsByProductIdHandler(ReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<List<Review>> Handle(GetReviewsByProductIdQuery request, CancellationToken cancellationToken)
        {
            return await _reviewRepository.GetReviewsByProductIdAsync(request.ProductId);
        }
    }
}
