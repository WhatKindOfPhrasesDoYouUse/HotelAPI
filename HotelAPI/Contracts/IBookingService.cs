using HotelAPI.Models;

namespace HotelAPI.Contracts
{
    public interface IBookingService
    {
        Task<IEnumerable<Booking>> GetAllBookings();
    }
}
