using HotelAPI.Contracts;
using HotelAPI.Models;
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
                return NotFound();
            }

            return Ok(hotelReviews);
        }

        [HttpGet("GetHotelReviewById/{id}")]
        public async Task<IActionResult> GetHotelReviewById(long id)
        {
            var hotelReview = await _hotelReviewService.GetHotelReviewById(id);

            if (hotelReview == null)
            {
                return NotFound();
            }

            return Ok(hotelReview);
        }

        [HttpPost("AddRoom")]
        public async Task<IActionResult> AddHotelReview(HotelReview hotelReview)
        {
            if (hotelReview == null)
            {
                return BadRequest();
            }

            bool result = await _hotelReviewService.AddHotelReview(hotelReview);

            if (result)
            {
                return Ok(result);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPut("UpdateHotelReview/{id}")]
        public async Task<IActionResult> UpdateHotelReview(long id, HotelReview hotelReview)
        {
            if (hotelReview == null)
            {
                return BadRequest();
            }

            bool result = await _hotelReviewService.UpdateHotelReview(id, hotelReview);

            if (!result)
            {
                return NotFound();
            }

            return Ok(hotelReview);
        }

        [HttpDelete("DeleteHotelReviewById/{id}")]
        public async Task<IActionResult> DeleteHotelReviewById(long id)
        {
            var result = await _hotelReviewService.DeleteHotelReviewById(id);

            if (!result)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}