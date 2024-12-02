using HotelAPI.DTO;
using HotelAPI.Models;

namespace HotelAPI.Contracts
{
    public interface IRoomService
    {
        Task<IEnumerable<RoomDTO>> GetAllRooms();
        Task<RoomDTO?> GetRoomById(long id);
        Task<bool> DeleteRoomById(long id);
        Task<bool> AddRoom(Room room);
        Task<bool> UpdateRoom(long id, Room room);
    }
}
