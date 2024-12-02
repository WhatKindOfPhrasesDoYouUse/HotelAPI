using HotelAPI.Models;

namespace HotelAPI.DTO
{
    public class HotelReviewDTO
    {
        public long? Id { get; set; }
        public string? Comment { get; set; }
        public DateOnly? PublishDate { get; set; }
        public int? Rating { get; set; }
        public long? HotelId { get; set; }
        public long? UserAccountId { get; set; }
        public virtual HotelSummaryDTO? Hotel { get; set; } = null!;
        public virtual UserAccountSummaryDTO? UserAccount { get; set; } = null!;
    }
}
