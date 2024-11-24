using HotelAPI.Contracts;
using HotelAPI.Data;
using HotelAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Services
{
    /// <summary>
    /// Сервис предоставляющий бизнесс логику взаимодействия с путевками системы.
    /// </summary>
    public class TravelService : ITravelService
    {

        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Инициализация экземпляра типа <see cref="TravelService"/> с контекстом базы данных.
        /// </summary>
        /// <param name="context"></param>
        public TravelService(ApplicationDbContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Возвращает список всех путешествий.
        /// </summary>
        /// <returns>
        /// Асинхронная операция, которая возвращает коллекцию объектов <see cref="Travel"/>.
        /// Если путешествия отсутствуют, возвращает <c>null</c>.
        /// </returns>
        public async Task<IEnumerable<Travel>> GetAllTravels()
        {
            var travels = await _context.Travels.ToListAsync();

            if (travels != null || travels.Any())
            {
                return travels;
            }
            else
            {
                return null;
            }
        }
    }
}
