using HotelAPI.DTO;
using HotelAPI.Models;

namespace HotelAPI.Contracts
{
    public interface IBookingService
    {
        Task<IEnumerable<BookingDTO>> GetAllBookings();
        Task<BookingDTO?> GetBookingById(long id);
        Task<bool> AddBooking(Booking booking);
        Task<bool> DeleteBookingById(long id);
    }
}
