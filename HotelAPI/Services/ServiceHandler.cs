using HotelAPI.Contracts;
using HotelAPI.Data;
using HotelAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Services
{
    public class ServiceHandler : IServiceHandler
    {
        private readonly ApplicationDbContext _context;

        public ServiceHandler(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Service>> GetAllServices()
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
