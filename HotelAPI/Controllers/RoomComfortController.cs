using HotelAPI.Contracts;
using HotelAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomComfortController : ControllerBase
    {
        private readonly IRoomComfortService _roomComfortService;

        public RoomComfortController(IRoomComfortService roomComfortService)
        {
            this._roomComfortService = roomComfortService;
        }

        [HttpGet("GetRoomComfort")]
        public async Task<IActionResult> GetRoomComfort()
        {
            var roomComfort = await _roomComfortService.GetAllRoomsComforts();

            if (roomComfort == null)
            {
                return NotFound();
            }
            return Ok(roomComfort);
        }
    }
}
