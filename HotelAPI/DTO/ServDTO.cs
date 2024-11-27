namespace HotelAPI.DTO
{
    public class ServDTO
    {
        public long? Id { get; set; }
        public string? Name { get; set; } 
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public long? HotelId { get; set; }
    }
}
