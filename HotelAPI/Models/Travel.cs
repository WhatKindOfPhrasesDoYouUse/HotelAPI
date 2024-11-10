using System;
using System.Collections.Generic;

namespace HotelAPI.Models;

public partial class Travel
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public DateOnly DepartureDate { get; set; }

    public DateOnly ArrivalDate { get; set; }

    public int HotelId { get; set; }

    public virtual Hotel Hotel { get; set; } = null!;

    public virtual ICollection<PaymentTravel> PaymentTravels { get; set; } = new List<PaymentTravel>();

    public virtual ICollection<TravelReview> TravelReviews { get; set; } = new List<TravelReview>();
}
