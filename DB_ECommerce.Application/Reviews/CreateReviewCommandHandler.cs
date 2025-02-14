using DB_ECommerce.Models;
using DB_ECommerce.Persistence.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DB_ECommerce.Application.Reviews
{
    public class CreateReviewHandler : IRequestHandler<CreateReviewCommand, Review>
    {
        private readonly ReviewRepository _reviewRepository;

        public CreateReviewHandler(ReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<Review> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            var review = new Review
            {
                ProductId = request.ProductId,
                UserId = request.UserId,
                Rating = request.Rating,
                Comment = request.Comment,
                CreatedAt = DateTime.UtcNow
            };

            await _reviewRepository.CreateReviewAsync(review);
            return review;
        }
    }
}
