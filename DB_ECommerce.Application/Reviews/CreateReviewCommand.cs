using DB_ECommerce.Models;
using MediatR;

namespace DB_ECommerce.Application
{
    public class CreateReviewCommand : IRequest<Review>
    {
        public string ProductId { get; set; }
        public string UserId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}
