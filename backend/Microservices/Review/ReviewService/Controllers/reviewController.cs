using MediatR;
using Microsoft.AspNetCore.Mvc;
using MorvieReview.Application.Commands;
using MorvieReview.Application.Queries.GetAllReviews;
using MorvieReview.Application.Queries.GetReview;
using MorvieReview.Models;

namespace MorvieReview.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReviewController : Controller
    {
        private readonly IMediator _mediator;
        public ReviewController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //Retrieves all reviews from the system.
        [HttpGet]
        public async Task<IEnumerable<ReviewModel>> GetAll()
        {
            var query = new GetAllReviewsQuery();
            var result = await _mediator.Send(query);

            List<ReviewModel> reviews = new();
            foreach (var review in result)
            {
                reviews.Add(new ReviewModel(review.Id, review.Name, review.Description));
            }
            return reviews;
        }

        [HttpGet("{reviewId}")]
        public async Task<ActionResult<ReviewModel>> Get(Guid reviewId)
        {
            var result = await _mediator.Send(new GetReviewQuery(reviewId));
            var review = new ReviewModel()
            {
                Id = result.Id,
                Name = result.Name,
                Description = result.Description
            };

            return new OkObjectResult(review);
        }

        [IgnoreAntiforgeryToken(Order = 1000)]
        [HttpPost]
        public async Task<ActionResult> Create(string name, string description)
        {
            ReviewModel movie = new(Guid.NewGuid(), name, description);
            var command = new CreateReviewCommand(movie.Id, movie.Name, movie.Description);
            var response = await _mediator.Send(command);
            return new OkResult();
        }
    }
}
