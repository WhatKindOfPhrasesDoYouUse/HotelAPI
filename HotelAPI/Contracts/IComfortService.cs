using HotelAPI.Models;

namespace HotelAPI.Contracts
{
    public interface IComfortService
    {
        Task<IEnumerable<Comfort>> GetAllComforts();
    }
}
