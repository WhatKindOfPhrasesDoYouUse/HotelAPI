using HotelAPI.Contracts;
using HotelAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : Controller
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            this._roomService = roomService;
        }

        [HttpGet("GetRooms")]
        public async Task<IActionResult> GetRooms()
        {
            var rooms = await _roomService.GetAllRooms();

            if (rooms == null)
            {
                return NotFound("Комнаты не найдены");
            }

            return Ok(rooms);
        }
    }
}
