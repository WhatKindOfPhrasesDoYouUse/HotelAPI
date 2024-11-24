using HotelAPI.Models;

namespace HotelAPI.Contracts
{
    // Это сущность service из бд
    public interface IServService
    {
        Task<IEnumerable<Serv>> GetAllServices();
    }
}
