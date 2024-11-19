using HotelAPI.Models;

namespace HotelAPI.Contracts
{
    public interface IPaymentRoomService
    {
        Task<IEnumerable<PaymentRoom>> GetAllPaymentRooms();
    }
}
