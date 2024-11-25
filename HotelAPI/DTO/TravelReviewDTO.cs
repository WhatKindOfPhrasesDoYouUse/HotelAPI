namespace HotelAPI.DTO
{
    public class TravelReviewDTO
    {
        public long Id { get; set; }
        public string Comment { get; set; }
        public DateOnly PublishDate { get; set; }
        public long TravelId { get; set; }
        public int Rating { get; set; }
        public long UserAccountId { get; set; }
    }
}
