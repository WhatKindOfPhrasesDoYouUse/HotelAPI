using HotelAPI.Contracts;
using HotelAPI.Data;
using HotelAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Services
{
    public class RequestServReviewService : IRequestServReviewService
    {
        private readonly ApplicationDbContext _context;

        public RequestServReviewService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RequestServReview>> GetAllRequestServiceReviews()
        {
            var requestServiceReviews = await _context.RequestServiceReviews.ToListAsync();

            if (requestServiceReviews == null)
            {
                return null;
            }
            else
            {
                return requestServiceReviews;
            }
        }
    }
}
