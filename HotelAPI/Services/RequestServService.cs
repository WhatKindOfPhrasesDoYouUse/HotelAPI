using HotelAPI.Contracts;
using HotelAPI.Data;
using HotelAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Services
{
    public class RequestServService : IRequestServService
    {
        private readonly ApplicationDbContext _context;

        public RequestServService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RequestServ>> GetAllRequestServices()
        {
            var requestServices = await _context.RequestServices.ToListAsync();

            if (requestServices == null)
            {
                return null;
            }
            else
            {
                return requestServices;
            }
        }
    }
}
