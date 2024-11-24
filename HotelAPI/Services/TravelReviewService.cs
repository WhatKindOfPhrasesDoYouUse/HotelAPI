using HotelAPI.Contracts;
using HotelAPI.Data;
using HotelAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Services
{
    public class TravelReviewService : ITravelReviewService
    {
        private readonly ApplicationDbContext _context;

        public TravelReviewService(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<TravelReview>> GetAllTravelReviews()
        {
            var travelReviews = await _context.TravelReviews.ToListAsync();

            if (travelReviews != null || travelReviews.Any())
            {
                return travelReviews;
            }
            else
            {
                return null;
            }
        }

    }
}
