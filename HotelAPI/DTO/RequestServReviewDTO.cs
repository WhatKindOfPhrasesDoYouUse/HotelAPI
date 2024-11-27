namespace HotelAPI.DTO
{
    public class RequestServReviewDTO
    {
        public long? Id { get; set; }
        public string? Comment { get; set; }
        public DateOnly? PublishDate { get; set; }
        public int? Rating { get; set; }
        public long? RequestServiceId { get; set; }
        public long? UserAccountId { get; set; }
    }
}
