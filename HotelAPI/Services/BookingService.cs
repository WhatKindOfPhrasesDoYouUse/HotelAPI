using HotelAPI.Contracts;
using HotelAPI.Data;
using HotelAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Services
{
    public class BookingService : IBookingService
    {
        private readonly ApplicationDbContext _context;

        public BookingService(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Booking>> GetAllBookings()
        {
            var bookings = await _context.Bookings.ToListAsync();

            if (bookings == null)
            {
                return null;
            }
            else
            {
                return bookings;
            }
        }
    }
}
