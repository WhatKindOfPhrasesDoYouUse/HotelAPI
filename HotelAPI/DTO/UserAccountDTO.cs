using System.Text.Json.Serialization;

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
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public ICollection<UserRoleDTO>? Roles { get; set; } = new List<UserRoleDTO>();
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public ICollection<BookingDTO>? Bookings { get; set; } = new List<BookingDTO>();
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public ICollection<HotelReviewDTO>? HotelReviews { get; set; } = new List<HotelReviewDTO>();
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public ICollection<HotelDTO>? Hotels { get; set; } = new List<HotelDTO>();
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public ICollection<RequestServDTO>? RequestServices { get; set; } = new List<RequestServDTO>();
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public ICollection<RequestServReviewDTO>? RequestServiceReviews { get; set; } = new List<RequestServReviewDTO>();
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public ICollection<PaymentTravelDTO>? PaymentTravels { get; set; } = new List<PaymentTravelDTO>();
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public ICollection<TravelReviewDTO>? TravelReviews { get; set; } = new List<TravelReviewDTO>();
    }
}
