using HotelAPI.Models;

namespace HotelAPI.Contracts
{
    public interface ITravelReviewService
    {
        Task<IEnumerable<TravelReview>> GetAllTravelReviews();
    }
}
