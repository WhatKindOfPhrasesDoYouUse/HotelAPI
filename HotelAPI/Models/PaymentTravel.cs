using System;
using System.Collections.Generic;

namespace HotelAPI.Models;

public partial class PaymentTravel
{
    public int Id { get; set; }

    public int Price { get; set; }

    public string PaymentStatus { get; set; } = null!;

    public DateOnly PaymentDate { get; set; }

    public int TravelId { get; set; }

    public int UserAccountId { get; set; }

    public virtual Travel Travel { get; set; } = null!;

    public virtual UserAccount UserAccount { get; set; } = null!;
}
