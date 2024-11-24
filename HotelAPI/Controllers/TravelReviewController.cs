using HotelAPI.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelReviewController : ControllerBase
    {
        private readonly ITravelReviewService _travelReviewService;

        public TravelReviewController(ITravelReviewService travelReviewService)
        {
            _travelReviewService = travelReviewService;
        }

        [HttpGet("GetTravelReviews")]
        public async Task<IActionResult> GetTravelReviews()
        {
            var travelReviews = await _travelReviewService.GetAllTravelReviews();

            if (travelReviews == null)
            {
                return NotFound();
            }

            return Ok(travelReviews);
        }
    }
}
