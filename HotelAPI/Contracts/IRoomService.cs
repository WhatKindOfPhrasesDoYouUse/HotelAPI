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
        Task<IEnumerable<RoomSummaryDTO>> GetAvailableRooms(long hotelId);
        Task<int> GetRoomCount(long hotelId);
        Task<IEnumerable<RoomDTO>> GetFilteredRooms(long hotelId, int? capacity, decimal? minPrice, decimal? maxPrice, string? roomType);
    }
}
