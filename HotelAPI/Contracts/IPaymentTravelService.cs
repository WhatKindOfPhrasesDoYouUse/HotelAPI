using HotelAPI.Models;

namespace HotelAPI.Contracts
{
    public interface IPaymentTravelService
    {
        Task<IEnumerable<PaymentTravel>> GetAllPaymentTravels();
    }
}
