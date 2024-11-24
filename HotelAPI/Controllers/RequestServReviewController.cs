using HotelAPI.Contracts;
using HotelAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestServReviewController : ControllerBase
    {
        private readonly IRequestServReviewService _requestServReviewService;

        public RequestServReviewController(IRequestServReviewService requestServReviewService)
        {
            _requestServReviewService = requestServReviewService;
        }

        [HttpGet("GetRequestServReview")]
        public async Task<IActionResult> GetRequestServReview()
        {
            var requestServicesReviews = await _requestServReviewService.GetAllRequestServiceReviews();

            if (requestServicesReviews == null)
            {
                return BadRequest();
            }

            return Ok(requestServicesReviews);
        }
    }
}
