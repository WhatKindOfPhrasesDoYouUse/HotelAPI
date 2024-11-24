using HotelAPI.Models;

namespace HotelAPI.Contracts
{
    /// <summary>
    /// Интерфейс создающий контракт Travel сервиса.
    /// </summary>
    public interface ITravelService
    {
        /// <summary>
        /// Метод возвращающий список всех доступных путевок, которые предоставляет отель.
        /// </summary>
        /// <returns>Асинхронный метод, который возвращает коллекцию объектов типа Travel</returns>
        Task<IEnumerable<Travel>> GetAllTravels();
    }
}
