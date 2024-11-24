using HotelAPI.Contracts;
using HotelAPI.Data;
using HotelAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Services
{
    public class PaymentTravelService : IPaymentTravelService
    {
        private readonly ApplicationDbContext _context;

        public PaymentTravelService(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<PaymentTravel>> GetAllPaymentTravels()
        {
            var paymentTravels = await _context.PaymentTravels.ToListAsync();

            if (paymentTravels == null)
            {
                return null;
            }
            else
            {
                return paymentTravels;
            }
        }
    }
}
