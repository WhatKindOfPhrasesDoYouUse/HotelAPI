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
            var hotelTypes = await _context.HotelTypes.ToListAsync();

            if (hotelTypes != null || hotelTypes.Any())
            {
                return hotelTypes;
            }
            else
            {
                return null;
            }
        }
    }
}
