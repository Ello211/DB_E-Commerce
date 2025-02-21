using MediatR;

namespace DB_ECommerce.Application.Reviews
{
    public class DeleteReviewCommand : IRequest<bool>
    {
        public string ReviewId { get; set; }

        public DeleteReviewCommand(string reviewId)
        {
            ReviewId = reviewId;
        }
    }
}
