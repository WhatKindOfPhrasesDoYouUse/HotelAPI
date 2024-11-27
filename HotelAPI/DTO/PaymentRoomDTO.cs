namespace HotelAPI.DTO
{
    public class PaymentRoomDTO
    {
        public long? Id { get; set; }
        public double? Price { get; set; }
        public string? PaymentType { get; set; }
        public string? PaymentStatus { get; set; }
        public DateOnly? PaymentDate { get; set; }
        public long? BookingId { get; set; }
    }
}
