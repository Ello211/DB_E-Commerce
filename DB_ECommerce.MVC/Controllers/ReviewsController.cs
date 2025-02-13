using DB_ECommerce.Application;
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

        [HttpPost]
        public async Task<ActionResult<Review>> CreateReview([FromBody] CreateReviewCommand command)
        {
            var review = await _mediator.Send(command);
            return CreatedAtAction(nameof(CreateReview), new { id = review.Id }, review);
        }
    }
}
