using HotelAPI.Contracts;
using HotelAPI.Data;
using HotelAPI.DTO;
using HotelAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Services
{
    /// <summary>
    /// HotelTypeService реализует бизнес логику API для взаимодействия с картами пользователей
    /// </summary>
    public class HotelTypeService : IHotelTypeService
    {

        // README: Оставлю пока справочник статическим, т.к. типы отеля появляются очень редко, и большой нужды в динамике пока нет.

        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Конструктор для создания экземпляра сервиса.
        /// </summary>
        /// <param name="context">Контекст базы данных для работы с данными приложения.</param>
        public HotelTypeService(ApplicationDbContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Конструктор для создания экземпляра сервиса.
        /// </summary>
        /// <param name="context">Контекст базы данных для работы с данными приложения.</param>
        public async Task<IEnumerable<HotelTypeDTO>> GetAllHotelTypes()
        {
            var hotelTypes = await _context.HotelTypes
                .Include(ht => ht.Hotels) 
                .Select(ht => new HotelTypeDTO
                {
                    Id = ht.Id,
                    Name = ht.Name,
                    Description = ht.Description,
                    HotelSummaries = ht.Hotels.Select(h => new HotelSummaryDTO
                    {
                        Id = h.Id,
                        Name = h.Name,
                        Address = h.Address,
                        City = h.City,
                        Description = h.Description,
                        PhoneNumber = h.PhoneNumber,
                        Email = h.Email,
                        Rating = h.Rating,
                        ManagerId = h.ManagerId,
                        HotelTypeId = h.HotelTypeId
                    }).ToList()
                }).ToListAsync();

            return hotelTypes;
        }

        /// <summary>
        /// Асинхронный метод для получения всех типов отелей с краткой информацией об отелях, связанных с каждым типом.
        /// </summary>
        /// <returns>Список объектов HotelTypeDTO, содержащих информацию о типах отелей и связанных с ними отелях.</returns>
        public async Task<HotelTypeDTO?> GetHotelTypeById(long id)
        {
            var hotelType = await _context.HotelTypes
                .Include(ht => ht.Hotels)
                .Where(ht => ht.Id == id)
                .Select(ht => new HotelTypeDTO
                {
                    Id = ht.Id,
                    Name = ht.Name,
                    Description = ht.Description,
                    HotelSummaries = ht.Hotels.Select(h => new HotelSummaryDTO
                    {
                        Id = h.Id,
                        Name = h.Name,
                        Address = h.Address,
                        City = h.City,
                        Description = h.Description,
                        PhoneNumber = h.PhoneNumber,
                        Email = h.Email,
                        Rating = h.Rating,
                        ManagerId = h.ManagerId,
                        HotelTypeId = h.HotelTypeId
                    }).ToList() 
                })
                .FirstOrDefaultAsync();

            return hotelType;
        }
    }
}
