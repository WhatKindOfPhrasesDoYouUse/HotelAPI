using HotelAPI.Contracts;
using HotelAPI.Models;
using HotelAPI.Services;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "client")]
        public async Task<IActionResult> GetRooms()
        {
            var rooms = await _roomService.GetAllRooms();

            if (rooms == null)
            {
                return NotFound();
            }

            return Ok(rooms);
        }

        [HttpGet("GetRoomById/{id}")]
        public async Task<IActionResult> GetRoomById(long id)
        {
            var room = await _roomService.GetRoomById(id);

            if (room == null)
            {
                return NotFound();
            }

            return Ok(room);
        }

        [HttpPost("AddRoom")]
        public async Task<IActionResult> AddRoom(Room room)
        {
            if (room == null)
            {
                return BadRequest();
            }

            bool result = await _roomService.AddRoom(room);

            if (!result)
            {
                return Conflict();
            }

            return CreatedAtAction(nameof(GetRooms), new { id = room.Id }, room);
        }

        [HttpPut("UpdateRoom/{id}")]
        public async Task<IActionResult> UpdateRoom(long id, Room room)
        {
            if (room == null)
            {
                return BadRequest();
            }

            bool result = await _roomService.UpdateRoom(id, room);

            if (!result)
            {
                return NotFound();
            }

            return Ok(room);
        }

        [HttpDelete("DeleteRoomById/{id}")]
        public async Task<IActionResult> DeleteRoomById(long id)
        {
            var result = await _roomService.DeleteRoomById(id);

            if (!result)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("GetAvailableRooms/{hotelId}")]
        public async Task<IActionResult> GetAvailableRooms(long hotelId)
        {
            var availableRooms = await _roomService.GetAvailableRooms(hotelId);
            return Ok(availableRooms);
        }

        [HttpGet("GetAvailableRoomsCount/{hotelId}")]
        public async Task<ActionResult<int>> GetRoomCount(long hotelId)
        {
            var roomCount = await _roomService.GetRoomCount(hotelId);
            return Ok(roomCount);
        }

        [HttpGet("FilteredRooms")]
        public async Task<IActionResult> GetFilteredRooms([FromQuery] long hotelId, [FromQuery] int? capacity, [FromQuery] decimal? minPrice, [FromQuery] decimal? maxPrice, [FromQuery] string? roomType)
        {
            var rooms = await _roomService.GetFilteredRooms(hotelId, capacity, minPrice, maxPrice, roomType);
            return Ok(rooms);
        }

        [HttpGet("SortedHotelsByPrice")]
        public async Task<IActionResult> GetSortedRoomeByPrice([FromQuery] long hotelId, [FromQuery] bool? sortByPriceDescending)
        {
            var rooms = await _roomService.SortRoomsByPrice(hotelId, sortByPriceDescending);
            return Ok(rooms);
        }
    }
}
