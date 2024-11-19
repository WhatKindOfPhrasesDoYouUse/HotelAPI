using HotelAPI.Contracts;
using HotelAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HotelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelReviewController : ControllerBase
    {
        private readonly IHotelReviewService _hotelReviewService;

        public HotelReviewController(IHotelReviewService hotelReviewService)
        {
            this._hotelReviewService = hotelReviewService;
        }

        [HttpGet("GetHotelReviews")]
        public async Task<IActionResult> GetHotelReviews()
        {
            var hotelReviews = await _hotelReviewService.GetAllHotelReviews();

            if (hotelReviews == null)
            {
                return NotFound("Отзывы на отели не найдены");
            }

            return Ok(hotelReviews);
        }
    }
}