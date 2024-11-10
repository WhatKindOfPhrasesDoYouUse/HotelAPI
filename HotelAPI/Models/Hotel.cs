using System;
using System.Collections.Generic;

namespace HotelAPI.Models;

public partial class Hotel
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateOnly? ConstructionYear { get; set; }

    public int? Rating { get; set; }

    public int ManagerId { get; set; }

    public int HotelTypeId { get; set; }

    public virtual ICollection<HotelReview> HotelReviews { get; set; } = new List<HotelReview>();

    public virtual HotelType HotelType { get; set; } = null!;

    public virtual UserAccount Manager { get; set; } = null!;

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();

    public virtual ICollection<Travel> Travels { get; set; } = new List<Travel>();
}
