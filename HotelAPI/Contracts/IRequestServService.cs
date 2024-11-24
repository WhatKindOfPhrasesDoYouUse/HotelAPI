using HotelAPI.Models;

namespace HotelAPI.Contracts
{
    public interface IRequestServService
    {
        Task<IEnumerable<RequestServ>> GetAllRequestServices();
    }
}
