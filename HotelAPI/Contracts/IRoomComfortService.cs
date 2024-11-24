namespace HotelAPI.Contracts
{
    public interface IRoomComfortService
    {
        Task<IEnumerable<object>> GetAllRoomsComforts();
    }
}
