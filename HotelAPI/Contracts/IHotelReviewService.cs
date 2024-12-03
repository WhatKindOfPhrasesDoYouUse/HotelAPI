using HotelAPI.DTO;
using HotelAPI.Models;

namespace HotelAPI.Contracts
{
    public interface IHotelReviewService
    {
        Task<IEnumerable<HotelReviewDTO>> GetAllHotelReviews();
        Task<HotelReviewDTO?> GetHotelReviewById(long id);
        Task<IEnumerable<HotelReviewDTO>> GetHotelReviewsByHotelId(long hotelId);
        Task<bool> AddHotelReview(HotelReview hotelReview);
        Task<bool> UpdateHotelReview(long id, HotelReview hotelReview);
        Task<bool> DeleteHotelReviewById(long id);
    }
}