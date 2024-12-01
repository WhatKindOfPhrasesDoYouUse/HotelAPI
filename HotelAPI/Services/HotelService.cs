using AutoMapper;
using HotelAPI.Contracts;
using HotelAPI.Data;
using HotelAPI.DTO;
using HotelAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Services
{
    public class HotelService : IHotelService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        // TODO: обязательно нужно проверить валидацию модели, а то она кривовата.

        public HotelService(ApplicationDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

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
    }
}
