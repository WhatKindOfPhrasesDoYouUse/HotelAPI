using HotelAPI.Contracts;
using HotelAPI.Data;
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

        public async Task<IEnumerable<HotelType>> GetAllHotelTypes()
        {
            var hotelTypes = await _context.HotelTypes
                .Include(ht => ht.Hotels)
                .ToListAsync();

            if (hotelTypes != null || hotelTypes.Any())
            {
                return hotelTypes;
            }
            else
            {
                return null;
            }
        }

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
