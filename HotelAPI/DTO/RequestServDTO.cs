namespace HotelAPI.DTO
{
    public class RequestServDTO
    {
        public long? Id { get; set; }
        public DateOnly? RequestDate { get; set; }
        public TimeOnly? RequestTime { get; set; }
        public string? RequestStatus { get; set; }
        public string? AdditionalNotes { get; set; }
        public int? QuantityRequests { get; set; }
        public long? ServiceId { get; set; }
        public long? UserAccountId { get; set; }
    }
}
