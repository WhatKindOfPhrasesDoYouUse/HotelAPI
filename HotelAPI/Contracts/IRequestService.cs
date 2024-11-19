using HotelAPI.Models;

namespace HotelAPI.Contracts
{
    public interface IRequestService
    {
        Task<IEnumerable<RequestService>> GetAllRequestServices();
    }
}
