using HotelAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Services
{
    public class RequestHandlerService
    {
        private readonly ApplicationDbContext _context;

        public RequestHandlerService(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<HotelAPI.Models.RequestService>> GetAllRequestServices()
        {
            var requestServices = await _context.RequestServices.ToListAsync();

            if (requestServices != null || requestServices.Any())
            {
                return requestServices;
            }
            else
            {
                return null;
            }
        }
    }
}
