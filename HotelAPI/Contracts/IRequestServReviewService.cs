using HotelAPI.Models;

namespace HotelAPI.Contracts
{
    public interface IRequestServReviewService
    {
        Task<IEnumerable<RequestServReview>> GetAllRequestServiceReviews();
    }
}
