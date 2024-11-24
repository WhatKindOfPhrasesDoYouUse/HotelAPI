using HotelAPI.Contracts;
using HotelAPI.Data;
using HotelAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Services
{
    public class ServService : IServService
    {
        private readonly ApplicationDbContext _context;

        public ServService(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Serv>> GetAllServices()
        {
            var services = await _context.Services.ToListAsync();

            if (services != null || services.Any())
            {
                return services;
            }
            else
            {
                return null;
            }
        }
    }
}
