namespace HotelAPI.DTO
{
    public class UserAccountDTO
    {
        public long? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public long? CardId { get; set; }
        public CardDTO? Card { get; set; }
        public ICollection<UserRoleDTO> Roles { get; set; } = new List<UserRoleDTO>();
        public ICollection<BookingDTO> Bookings { get; set; } = new List<BookingDTO>();
        public ICollection<HotelReviewDTO> HotelReviews { get; set; } = new List<HotelReviewDTO>();
        public ICollection<HotelDTO> Hotels { get; set; } = new List<HotelDTO>();
        public ICollection<RequestServDTO> RequestServices { get; set; } = new List<RequestServDTO>();
        public ICollection<RequestServReviewDTO> RequestServiceReviews { get; set; } = new List<RequestServReviewDTO>();
        public ICollection<PaymentTravelDTO> PaymentTravels { get; set; } = new List<PaymentTravelDTO>();
        public ICollection<TravelReviewDTO> TravelReviews { get; set; } = new List<TravelReviewDTO>();
    }
}
