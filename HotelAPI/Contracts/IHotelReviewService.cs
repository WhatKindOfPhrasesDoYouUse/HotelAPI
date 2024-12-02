using HotelAPI.DTO;
using HotelAPI.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Contracts
{
    public interface IHotelReviewService
    {
        Task<IEnumerable<HotelReviewDTO>> GetAllHotelReviews();
        Task<HotelReviewDTO?> GetHotelReviewById(long id);
        Task<bool> AddHotelReview(HotelReview hotelReview);
        Task<bool> UpdateHotelReview(long id, HotelReview hotelReview);
        Task<bool> DeleteHotelReviewById(long id);
    }
}