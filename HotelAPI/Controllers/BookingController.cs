using HotelAPI.Contracts;
using HotelAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            this._bookingService = bookingService;
        }

        [HttpGet("GetBookings")]
        public async Task<IActionResult> GetBookings()
        {
            var bookings = await _bookingService.GetAllBookings();

            if (bookings == null)
            {
                return NotFound();
            }

            return Ok(bookings);
        }

        [HttpGet("GetBookingById/{id}")]
        public async Task<IActionResult> GetBookingById(long id)
        {
            var booking = await _bookingService.GetBookingById(id);

            if (booking == null)
            {
                return NotFound();
            }

            return Ok(booking);
        }

        [HttpDelete("DeleteBookingById/{id}")]
        public async Task<IActionResult> DeleteBookingById(long id)
        {
            var result = await _bookingService.DeleteBookingById(id);

            if (!result)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}