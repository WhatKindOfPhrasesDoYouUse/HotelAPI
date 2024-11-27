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
        private readonly ApplicationDbContext _context;

        public HotelTypeService(ApplicationDbContext context)
        {
            this._context = context;
        }

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
