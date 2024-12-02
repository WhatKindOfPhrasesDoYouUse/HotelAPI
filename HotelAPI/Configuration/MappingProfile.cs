using AutoMapper;
using HotelAPI.DTO;
using HotelAPI.Models;

namespace HotelAPI.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Сделать нормальный маппинг Hotel

            CreateMap<Hotel, HotelDTO>()
                .ForMember(dest => dest.HotelReviews, opt => opt.MapFrom(src => src.HotelReviews))
                .ForMember(dest => dest.Rooms, opt => opt.MapFrom(src => src.Rooms))
                .ForMember(dest => dest.Services, opt => opt.MapFrom(src => src.Services))
                .ForMember(dest => dest.Travels, opt => opt.MapFrom(src => src.Travels));

            CreateMap<Room, RoomDTO>()
                .ForMember(dest => dest.Bookings, opt => opt.MapFrom(src => src.Bookings))
                .ForMember(dest => dest.Hotel, opt => opt.MapFrom(src => src.Hotel))
                .ForMember(dest => dest.Comforts, opt => opt.MapFrom(src => src.Comforts));

            CreateMap<Hotel, HotelSummaryDTO>();
            CreateMap<UserAccount, UserAccountDTO>();
            CreateMap<Card, CardDTO>();
            CreateMap<UserRole, UserRoleDTO>();
            CreateMap<Booking, BookingDTO>();
            CreateMap<HotelReview, HotelReviewDTO>();
            CreateMap<RequestServ, RequestServDTO>();
            CreateMap<RequestServReview, RequestServReviewDTO>();
            CreateMap<PaymentTravel, PaymentTravelDTO>();
            CreateMap<TravelReview, TravelReviewDTO>();
            CreateMap<HotelType, HotelTypeDTO>();
            CreateMap<Room, RoomDTO>();
            CreateMap<Serv, ServDTO>();
            CreateMap<Travel, TravelDTO>();
        }
    }
}
