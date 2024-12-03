using AutoMapper;
using HotelAPI.Contracts;
using HotelAPI.Data;
using HotelAPI.DTO;
using HotelAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Services
{
    public class BookingService : IBookingService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BookingService(ApplicationDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<BookingDTO>> GetAllBookings()
        {
            var bookings = await _context.Bookings
                .Include(b => b.PaymentRooms)
                .Include(b => b.Room)
                .Include(b => b.UserAccount)
                .ToListAsync();

            return _mapper.Map<IEnumerable<BookingDTO>>(bookings);
        }

        public async Task<BookingDTO?> GetBookingById(long id)
        {
            var booking = await _context.Bookings
                .Include(b => b.PaymentRooms)
                .Include(b => b.Room)
                .Include(b => b.UserAccount)
                .FirstOrDefaultAsync(b => b.Id == id);

            return _mapper.Map<BookingDTO>(booking);
        }

        public async Task<bool> AddBooking(Booking booking)
        {
            return false;
        }

        public async Task<bool> DeleteBookingById(long id)
        {
            var booking = await _context.Bookings.FirstOrDefaultAsync(b => b.Id == id);

            if (booking == null)
            {
                return false;
            }

            _context.PaymentRooms.RemoveRange(booking.PaymentRooms);
            _context.Bookings.Remove(booking);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
