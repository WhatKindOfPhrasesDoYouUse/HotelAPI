using HotelAPI.Contracts;
using HotelAPI.Data;
using HotelAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Services
{
    public class RoomService : IRoomService
    {
        private readonly ApplicationDbContext _context;

        public RoomService(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Room>> GetAllRooms()
        {
            var rooms = await _context.Rooms.ToListAsync();

            if (rooms == null)
            {
                return null;
            }
            else
            {
                return rooms;
            }
        }

    }
}
