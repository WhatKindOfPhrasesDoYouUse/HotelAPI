using HotelAPI.DTO;
using HotelAPI.Models;

namespace HotelAPI.Contracts
{
    public interface IHotelService
    {
        Task<IEnumerable<HotelDTO>> GetAllHotels();
        Task<HotelDTO?> GetHotelById(long id);
        Task<bool> DeleteById(long id);
        Task<bool> AddHotel(Hotel hotel);
        Task<bool> UpdateHotel(long id, Hotel hotel);
    }
}
