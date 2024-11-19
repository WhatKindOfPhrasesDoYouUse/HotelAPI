using HotelAPI.Models;

namespace HotelAPI.Contracts
{
    // Это сущность service из бд
    public interface IServiceHandler
    {
        Task<IEnumerable<Service>> GetAllServices();
    }
}
