using Microsoft.AspNetCore.Mvc;
using TouristNavigator.Application.Dto;
using TouristNavigator.Application.Interfaces.Services;
using TouristNavigator.Application.Services;

namespace TouristNavigator.API.Controllers
{
    [Route("review")]
    public class ReviewController : Controller
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet("getallreviews", Name = "GetAllReviews")]
        public async Task<ActionResult<List<ReviewDto>>> GetAllReviews()
        {
            return Ok(await _reviewService.GetAllReviewsAsync());
        }

        [HttpPost("createreview", Name = "CreateReview")]
        public async Task<ActionResult> CreateReview(ReviewDto review)
        {
            await _reviewService.AddReviewAsync(review);
            return Ok();
        }
    }
}
