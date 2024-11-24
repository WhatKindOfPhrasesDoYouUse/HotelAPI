using HotelAPI.Contracts;
using HotelAPI.Data;
using HotelAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Services
{
    public class HotelService : IHotelService
    {
        private readonly ApplicationDbContext _context;

        public HotelService(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Hotel>> GetAllHotels()
        {
            var hotels = await _context.Hotels
                .Include(h => h.Manager)
                .Include(h => h.HotelType)
                .ToListAsync();

            if (hotels != null || hotels.Any())
            {
                return hotels;
            }
            else
            {
                return null;
            }
        }
    }
}
