using HotelAPI.Contracts;
using HotelAPI.Data;
using HotelAPI.DTO;
using HotelAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Services
{
    public class HotelTypeService : IHotelTypeService
    {
        private readonly ApplicationDbContext _context;

        public HotelTypeService(ApplicationDbContext context)
        {
            this._context = context;
        }

        /*public async Task<IEnumerable<HotelTypeDTO>> GetAllHotelTypes()
        {
            var hotelTypes = await _context.HotelTypes
                .Include(ht => ht.Hotels)
                .ToListAsync();

            if (hotelTypes == null || !hotelTypes.Any())
            {
                return Enumerable.Empty<HotelTypeDTO>();
            }

            var hotelTypeDTOs = hotelTypes.Select(ht => new HotelTypeDTO
            {
                Id = ht.Id,
                Name = ht.Name,
                Description = ht.Description,
                HotelIds = ht.Hotels.Select(h => h.Id).ToList()
            });

            return hotelTypeDTOs;

        }*/

        public async Task<HotelType?> GetHotelTypeById(long id)
        {
            var hotelType = await _context.HotelTypes
                .Include(ht => ht.Hotels)
                .FirstOrDefaultAsync(ht => ht.Id == id);

            if (hotelType == null)
            {
                return null;
            }
            else
            {
                return hotelType;
            }
        }
    }
}
