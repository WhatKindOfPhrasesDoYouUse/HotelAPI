using AutoMapper;
using HotelAPI.DTO;
using HotelAPI.Models;

namespace HotelAPI.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserAccount, UserAccountDTO>();
            CreateMap<Card, CardDTO>();
            CreateMap<UserRole, UserRoleDTO>();
            CreateMap<Booking, BookingDTO>();
            CreateMap<HotelReview, HotelReviewDTO>();
            CreateMap<Hotel, HotelDTO>();
            CreateMap<RequestServ, RequestServDTO>();
            CreateMap<RequestServReview, RequestServReviewDTO>();
            CreateMap<PaymentTravel, PaymentTravelDTO>();
            CreateMap<TravelReview, TravelReviewDTO>();
            CreateMap<UserRole, UserRoleDTO>();
        }
    }
}
