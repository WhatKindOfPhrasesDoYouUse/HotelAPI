using HotelAPI.Contracts;
using HotelAPI.Data;
using HotelAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Services
{
    public class HotelReviewService : IHotelReviewService
    {
        private readonly ApplicationDbContext _context;

        public HotelReviewService(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<HotelReview>> GetAllHotelReviews()
        {
            var hotelReviews = await _context.HotelReviews.ToListAsync();

            if (hotelReviews == null)
            {
                return null;
            }
            else
            {
                return hotelReviews;
            }
        }
    }
}
