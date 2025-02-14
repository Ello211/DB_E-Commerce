using DB_ECommerce.Application.Reviews;
using DB_ECommerce.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DB_ECommerce.MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReviewsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST /api/reviews/
        [HttpPost]
        public async Task<ActionResult<Review>> CreateReview([FromBody] CreateReviewCommand command)
        {
            var review = await _mediator.Send(command);
            return CreatedAtAction(nameof(CreateReview), new { id = review.Id }, review);
        }
    

    
        // GET /api/reviews/product/{productId}
        [HttpGet("product/{productId}")]
        public async Task<ActionResult<List<Review>>> GetReviewsByProductId(string productId)
        {
            var reviews = await _mediator.Send(new GetReviewsByProductIdQuery(productId));

            if (reviews == null || reviews.Count == 0)
                return NotFound($"No reviews found for product {productId}");

            return Ok(reviews);
        }

        // DELETE /api/reviews/{reviewId}
        [HttpDelete("{reviewId}")]
        public async Task<ActionResult> DeleteReview(string reviewId)
        {
            var success = await _mediator.Send(new DeleteReviewCommand(reviewId));

            if (!success)
                return NotFound($"No review found with ID {reviewId}");

            // 204 No Content if deletion was successful
            return NoContent();  
        }

        // UPDATE /api/reviews/{reviewId}
        [HttpPut("{reviewId}")]
        public async Task<ActionResult> UpdateReview(string reviewId, [FromBody] UpdateReviewCommand command)
        {
            if (reviewId != command.ReviewId)
                return BadRequest("Review ID in the URL does not match the request body.");

            var success = await _mediator.Send(command);

            if (!success)
                return NotFound($"No review found with ID {reviewId}");

            // 204 No Content if update was successful
            return NoContent(); 
        }

        // GET /api/reviews/product/{productId}/rating
        [HttpGet("product/{productId}/rating")]
        public async Task<ActionResult<double?>> GetAverageRating(string productId)
        {
            var averageRating = await _mediator.Send(new GetAverageRatingQuery(productId));

            // Commented out as null is fine in table
            /*if (averageRating == null)
                return NotFound($"No reviews found for product {productId}");*/

            return Ok(averageRating);
        }
    }
}
