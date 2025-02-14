using DB_ECommerce.Models;
using MediatR;
using System.Collections.Generic;

namespace DB_ECommerce.Application.Reviews
{
    public class GetReviewsByProductIdQuery : IRequest<List<Review>>
    {
        public string ProductId { get; set; }

        public GetReviewsByProductIdQuery(string productId)
        {
            ProductId = productId;
        }
    }
}
