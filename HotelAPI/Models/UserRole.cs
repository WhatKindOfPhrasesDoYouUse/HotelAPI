using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelAPI.Models;

[Table(name: "user_role", Schema = "core")]
public partial class UserRole
{
    [Column(name: "user_id")]
    [Required]
    public long UserId { get; set; }

    [Column(name: "role_id")]
    [Required]
    public long RoleId { get; set; }

    public virtual Role Role { get; set; } = null!;

    public virtual UserAccount User { get; set; } = null!;
}