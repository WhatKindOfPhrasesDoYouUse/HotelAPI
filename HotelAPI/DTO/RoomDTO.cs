﻿using HotelAPI.Models;

namespace HotelAPI.DTO
{
    public class RoomDTO
    {
        public long? Id { get; set; }
        public string? RoomType { get; set; }
        public int? RoomNumber { get; set; }
        public int? Capacity { get; set;}
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public long? HotelId { get; set; }
        public virtual HotelSummaryDTO Hotel { get; set; } = null!;
        public virtual ICollection<BookingDTO>? Bookings { get; set; } = new List<BookingDTO>();
        public virtual ICollection<RoomComfort>? Comforts { get; set; } = new List<RoomComfort>();
    }
}
