using HotelAPI.Models;

namespace HotelAPI.Contracts
{
    public interface IRoomService
    {
        Task<IEnumerable<Room>> GetAllRooms();
    }
}
