using HotelAPI.Contracts;
using HotelAPI.Data;
using HotelAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Services
{
    public class ComfortService : IComfortService
    {
        private readonly ApplicationDbContext _context;

        public ComfortService(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Comfort>> GetAllComforts()
        {
            var comforts = await _context.Comforts.ToListAsync();

            if (comforts != null || comforts.Any())
            {
                return comforts;
            }
            else
            {
                return null;
            }
        }
    }
}
