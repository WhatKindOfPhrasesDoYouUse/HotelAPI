namespace HotelAPI.DTO
{
    public class PaymentTravelDTO
    {
        public long? Id { get; set; }
        public int? Price { get; set; }
        public string? PaymentStatus { get; set; }
        public DateOnly? PaymentDate { get; set; }
        public long? TravelId { get; set; }
        public long? UserAccountId { get; set;}
    }
}
