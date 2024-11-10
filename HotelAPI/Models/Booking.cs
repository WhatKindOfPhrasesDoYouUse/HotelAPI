using System;
using System.Collections.Generic;

namespace HotelAPI.Models;

public partial class Booking
{
    public int Id { get; set; }

    public DateOnly CheckIn { get; set; }

    public DateOnly CheckOut { get; set; }

    public decimal ActualPrice { get; set; }

    public int UserAccountId { get; set; }

    public int RoomId { get; set; }

    public virtual ICollection<PaymentRoom> PaymentRooms { get; set; } = new List<PaymentRoom>();

    public virtual Room Room { get; set; } = null!;

    public virtual UserAccount UserAccount { get; set; } = null!;
}
