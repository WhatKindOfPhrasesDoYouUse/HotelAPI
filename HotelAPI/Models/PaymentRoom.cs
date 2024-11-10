using System;
using System.Collections.Generic;

namespace HotelAPI.Models;

public partial class PaymentRoom
{
    public int Id { get; set; }

    public int Price { get; set; }

    public string PaymentStatus { get; set; } = null!;

    public DateOnly PaymentDate { get; set; }

    public int BookingId { get; set; }

    public virtual Booking Booking { get; set; } = null!;
}
