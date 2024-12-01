using HotelAPI.Models;

namespace HotelAPI.DTO
{
    public class HotelDTO
    {
        public long? Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set;}
        public string? City { get; set;}
        public string? Description{ get; set;} 
        public string? PhoneNumber { get; set;}
        public string? Email { get; set;}
        public int? Rating { get; set; }
        public long? ManagerId { get; set; }
        public long? HotelTypeId { get; set; }
        public virtual ICollection<HotelReviewDTO> HotelReviews { get; set; } = new List<HotelReviewDTO>();
        public virtual ICollection<RoomDTO> Rooms { get; set; } = new List<RoomDTO>();
        public virtual ICollection<ServDTO> Services { get; set; } = new List<ServDTO>();
        public virtual ICollection<TravelDTO> Travels { get; set; } = new List<TravelDTO>();
    }
}
