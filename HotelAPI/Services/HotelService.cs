using AutoMapper;
using HotelAPI.Contracts;
using HotelAPI.Data;
using HotelAPI.DTO;
using HotelAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Services
{
    /// <summary>
    /// Сервис для управления отелями, включая операции с созданием, обновлением, удалением и получением данных о гостиницах.
    /// </summary>
    public class HotelService : IHotelService
    {
        // TODO: обязательно нужно проверить валидацию модели, а то она кривовата.

        private readonly ApplicationDbContext _context;
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;

        // <summary>
        /// Конструктор сервиса.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        /// <param name="mapper">Интерфейс AutoMapper для преобразования между моделями и DTO.</param>
        public HotelService(ApplicationDbContext context, IMapper mapper, IRoomService roomService)
        {
            this._context = context;
            this._mapper = mapper;
            this._roomService = roomService;
        }

        /// <summary>
        /// Получить все гостиницы.
        /// </summary>
        /// <returns>Список всех гостиниц через DTO.</returns>
        public async Task<IEnumerable<HotelDTO>> GetAllHotels()
        {
            var hotels = await _context.Hotels
                .Include(h => h.HotelReviews)
                .Include(h => h.Rooms)
                .Include(h => h.Services)
                .Include(h => h.Travels)
                .ToListAsync();

            return _mapper.Map<IEnumerable<HotelDTO>>(hotels);
        }

        // <summary>
        /// Получить данные о гостинице по ID.
        /// </summary>
        /// <param name="id">ID гостиницы.</param>
        /// <returns>DTO гостиницы, или null, если гостиница не найдена.</returns>
        public async Task<HotelDTO?> GetHotelById(long id)
        {
            var hotel = await _context.Hotels
                .Include(h => h.HotelReviews)
                .Include(h => h.Rooms)
                .Include(h => h.Services)
                .Include(h => h.Travels)
                .FirstOrDefaultAsync(h => h.Id == id);

            return _mapper.Map<HotelDTO>(hotel);
        }

        /// <summary>
        /// Добавить новую гостиницу.
        /// </summary>
        /// <param name="hotel">Объект гостиницы для добавления.</param>
        /// <returns>True, если гостиница была успешно добавлена; False, если гостиница с таким email или номером телефона уже существует.</returns>
        public async Task<bool> AddHotel(Hotel hotel)
        {
            var findHotel = await _context.Hotels
                .FirstOrDefaultAsync(h => h.Email == hotel.Email || h.PhoneNumber == hotel.PhoneNumber);

            if (findHotel != null)
            {
                return false;
            }

            await _context.Hotels.AddAsync(hotel);
            await _context.SaveChangesAsync();

            return true;
        }

        /// <summary>
        /// Обновить данные гостиницы по ID.
        /// </summary>
        /// <param name="id">ID гостиницы, которую нужно обновить.</param>
        /// <param name="hotel">Обновленные данные гостиницы.</param>
        /// <returns>True, если гостиница была успешно обновлена; False, если гостиница с данным ID не найдена.</returns>
        public async Task<bool> UpdateHotel(long id, Hotel hotel)
        {
            var existingHotel = await _context.Hotels.FirstOrDefaultAsync(h => h.Id == id);

            if (existingHotel == null) 
            {
                return false;
            }

            existingHotel.Name = hotel.Name;
            existingHotel.Address = hotel.Address;
            existingHotel.City = hotel.City;
            existingHotel.Description = hotel.Description;
            existingHotel.PhoneNumber = hotel.PhoneNumber;
            existingHotel.Email = hotel.Email;
            existingHotel.ConstructionYear = hotel.ConstructionYear;
            existingHotel.Rating = hotel.Rating;
            existingHotel.ManagerId = hotel.ManagerId;
            existingHotel.HotelTypeId = hotel.HotelTypeId;

            await _context.SaveChangesAsync();

            return true;
        }

        /// <summary>
        /// Удалить гостиницу по ID.
        /// </summary>
        /// <param name="id">ID гостиницы, которую нужно удалить.</param>
        /// <returns>True, если гостиница была успешно удалена; False, если гостиница с данным ID не найдена.</returns>
        public async Task<bool> DeleteById(long id)
        {
            var hotel = await _context.Hotels.FirstOrDefaultAsync(h => h.Id == id);

            if (hotel == null)
            {
                return false;
            }

            // Удаляю связанные коллекции, без отеля нет и отзывов, комнат, сервисов и путешествий.
            _context.HotelReviews.RemoveRange(hotel.HotelReviews);
            _context.Rooms.RemoveRange(hotel.Rooms);
            _context.Services.RemoveRange(hotel.Services);
            _context.Travels.RemoveRange(hotel.Travels);

            _context.Hotels.Remove(hotel);

            await _context.SaveChangesAsync();

            return true;
        }

        // TODO: Переделать рейтинг под double

        public async Task<IEnumerable<HotelDTO>> GetFilteredHotels(string? city, int? minRating, int? minAvailableRooms)
        {
            var query = _context.Hotels
                .Include(h => h.HotelReviews)
                .Include(h => h.Rooms)
                .Include(h => h.Travels)
                .Include(h => h.Services)
                .AsQueryable();

            if (!string.IsNullOrEmpty(city))
            {
                query = query.Where(h => h.City.Contains(city));
            }

            if (minRating.HasValue)
            {
                query = query.Where(h => h.Rating >= minRating.Value);
            }

            var hotels = await query.ToListAsync();

            var filteredHotels = hotels
                .Where(h => !minAvailableRooms.HasValue || _roomService.GetRoomCount(h.Id).Result >= minAvailableRooms)
                .ToList();

            var hotelDTOs = _mapper.Map<IEnumerable<HotelDTO>>(filteredHotels);

            return hotelDTOs;
        }

    }
}
