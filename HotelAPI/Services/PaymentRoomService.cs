using HotelAPI.Contracts;
using HotelAPI.Data;
using HotelAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Services
{
    public class PaymentRoomService : IPaymentRoomService
    {
        private readonly ApplicationDbContext _context;

        public PaymentRoomService(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<PaymentRoom>> GetAllPaymentRooms()
        {
            var paymentRooms = await _context.PaymentRooms.ToListAsync();

            if (paymentRooms == null)
            {
                return null;
            }
            else
            {
                return paymentRooms;
            }
        }
    }
}
