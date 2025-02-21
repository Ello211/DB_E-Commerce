using DB_ECommerce.Persistence.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DB_ECommerce.Application.Reviews
{
    public class UpdateReviewHandler : IRequestHandler<UpdateReviewCommand, bool>
    {
        private readonly ReviewRepository _reviewRepository;

        public UpdateReviewHandler(ReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<bool> Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            return await _reviewRepository.UpdateReviewAsync(request.ReviewId, request.Rating, request.Comment);
        }
    }
}
