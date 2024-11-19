using HotelAPI.Models;

namespace HotelAPI.Contracts
{
    public interface IHotelService
    {
        Task<IEnumerable<Hotel>> GetAllHotels();
    }
}
