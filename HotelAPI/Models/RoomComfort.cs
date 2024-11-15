/*using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelAPI.Models;

[Table(name: "room_comfort", Schema = "core")]
public partial class RoomComfort
{
    [Column(name: "room_id")]
    [Required]
    public int RoomId { get; set; }

    [Column(name: "comfort_id")]
    [Required]
    public int ComfortId { get; set; }

    public virtual Comfort Comfort { get; set; } = null!;

    public virtual Room Room { get; set; } = null!;
}
*/