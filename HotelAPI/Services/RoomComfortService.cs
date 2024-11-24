using HotelAPI.Contracts;
using HotelAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Services
{
    public class RoomComfortService : IRoomComfortService
    {
        private readonly ApplicationDbContext _context;

        public RoomComfortService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<object>> GetAllRoomsComforts()
        {
            var result = await _context.RoomComforts
                .Include(rc => rc.Room)
                .Include(rc => rc.Comfort)
                .Select(rc => new
                {
                    RoomId = rc.RoomId,
                    ComfortId = rc.ComfortId
                })
                .ToListAsync();

            return result;
        }
    }
}
