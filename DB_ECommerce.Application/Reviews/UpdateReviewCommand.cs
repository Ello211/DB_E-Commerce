using MediatR;

namespace DB_ECommerce.Application.Reviews
{
    public class UpdateReviewCommand : IRequest<bool>
    {
        public string ReviewId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }

        public UpdateReviewCommand(string reviewId, int rating, string comment)
        {
            ReviewId = reviewId;
            Rating = rating;
            Comment = comment;
        }
    }
}
