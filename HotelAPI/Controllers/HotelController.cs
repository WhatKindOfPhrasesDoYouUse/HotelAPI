using HotelAPI.Contracts;
using HotelAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        // TODO: Написать доку к GET методам, и дописать UPDATE, DELETE, CREATE

        public HotelController(IHotelService hotelService)
        {
            this._hotelService = hotelService;
        }

        [HttpGet("GetHotels")]
        public async Task<IActionResult> GetHotels()
        {
            var hotels = await _hotelService.GetAllHotels();

            if (hotels == null)
            {
                return NotFound();
            }

            return Ok(hotels);
        }

        [HttpGet("GetHotelById/{id}")]
        public async Task<IActionResult> GetHotelById(long id)
        {
            var hotel = await _hotelService.GetHotelById(id);

            if (hotel == null)
            {
                return NotFound();
            }

            return Ok(hotel);
        }

        [HttpPost("AddHotel")]
        public async Task<IActionResult> AddHotel(Hotel hotel)
        {
            if (hotel == null)
            {
                return BadRequest();
            }

            bool result = await _hotelService.AddHotel(hotel);

            if (!result)
            {
                return Conflict();
            }

            return CreatedAtAction(nameof(GetHotels), new { id = hotel.Id }, hotel);
        }

        [HttpPut("UpdateHotel/{id}")]
        public async Task<IActionResult> UpdateHotel(long id, Hotel hotel)
        {
            if (hotel == null)
            {
                return BadRequest();
            }

            bool result = await _hotelService.UpdateHotel(id, hotel);

            if (!result)
            {
                return NotFound();
            }

            return Ok(hotel);
        }

        [HttpDelete("DeleteHotelById/{id}")]
        public async Task<IActionResult> DeleteHotelById(long id)
        {
            var result = await _hotelService.DeleteById(id);

            if (!result)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("FilteredHotels")]
        public async Task<IActionResult> GetFilteredHotels([FromQuery] string? city, [FromQuery] int? rating, [FromQuery] int? minAvailableRooms)
        {
            var hotels = await _hotelService.GetFilteredHotels(city, rating, minAvailableRooms);
            return Ok(hotels);
        }

        [HttpGet("SortedHotelsByRating")]
        public async Task<IActionResult> GetSortedHotelsByRating([FromQuery] bool? sortByRatingDescending)
        {
            var hotels = await _hotelService.SortHotelsByRating(sortByRatingDescending);
            return Ok(hotels);
        }
    }
}
