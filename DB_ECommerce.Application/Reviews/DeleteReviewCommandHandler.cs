using DB_ECommerce.Persistence.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DB_ECommerce.Application.Reviews
{
    public class DeleteReviewHandler : IRequestHandler<DeleteReviewCommand, bool>
    {
        private readonly ReviewRepository _reviewRepository;

        public DeleteReviewHandler(ReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<bool> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
        {
            return await _reviewRepository.DeleteReviewAsync(request.ReviewId);
        }
    }
}
