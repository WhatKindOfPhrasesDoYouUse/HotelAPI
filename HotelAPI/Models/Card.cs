using System;
using System.Collections.Generic;

namespace HotelAPI.Models;

public partial class Card
{
    public int Id { get; set; }

    public string Number { get; set; } = null!;

    public string Date { get; set; } = null!;

    public virtual ICollection<UserAccount> UserAccounts { get; set; } = new List<UserAccount>();
}
