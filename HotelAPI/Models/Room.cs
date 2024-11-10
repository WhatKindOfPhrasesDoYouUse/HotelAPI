using System;
using System.Collections.Generic;

namespace HotelAPI.Models;

public partial class Room
{
    public int Id { get; set; }

    public string RoomType { get; set; } = null!;

    public int RoomNumber { get; set; }

    public int Capacity { get; set; }

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public int HotelId { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual Hotel Hotel { get; set; } = null!;
}
