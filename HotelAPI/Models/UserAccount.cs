using System;
using System.Collections.Generic;

namespace HotelAPI.Models;

public partial class UserAccount
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Passport { get; set; } = null!;

    public int? CardId { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual Card? Card { get; set; }

    public virtual ICollection<HotelReview> HotelReviews { get; set; } = new List<HotelReview>();

    public virtual ICollection<Hotel> Hotels { get; set; } = new List<Hotel>();

    public virtual ICollection<PaymentTravel> PaymentTravels { get; set; } = new List<PaymentTravel>();

    public virtual ICollection<RequestServiceReview> RequestServiceReviews { get; set; } = new List<RequestServiceReview>();

    public virtual ICollection<RequestService> RequestServiceServices { get; set; } = new List<RequestService>();

    public virtual ICollection<RequestService> RequestServiceUserAccounts { get; set; } = new List<RequestService>();

    public virtual ICollection<TravelReview> TravelReviews { get; set; } = new List<TravelReview>();
}
