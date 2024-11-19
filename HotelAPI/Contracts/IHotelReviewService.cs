using HotelAPI.Models;

namespace HotelAPI.Contracts
{
    public interface IHotelReviewService
    {
        Task<IEnumerable<HotelReview>> GetAllHotelReviews();
    }
}
