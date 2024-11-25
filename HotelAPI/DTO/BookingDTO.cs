namespace HotelAPI.DTO
{
    public class BookingDTO
    {
        public long Id { get; set; }
        public DateOnly CheckIn { get; set; }
        public DateOnly CheckOut { get; set; }
        public decimal ActualPrice { get; set; }
        public long UserAccountId { get; set; }
        public long RoomId { get; set; }
    }
}
