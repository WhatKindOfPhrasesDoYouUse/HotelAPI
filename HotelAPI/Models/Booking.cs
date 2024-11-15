/*using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelAPI.Models;

[Table(name: "booking", Schema = "core")]
public partial class Booking
{
    [Column(name: "id")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column(name: "check_in")]
    [Required(ErrorMessage = "Дата заселения является обязательным параметром")]
    public DateOnly CheckIn { get; set; }

    [Column(name: "check_out")]
    [Required(ErrorMessage = "Дата выселения является обязательным параметром")]
    public DateOnly CheckOut { get; set; }

    [Column(name: "actual_price")]
    [Required(ErrorMessage = "Поле актуальной цены является обязательным параметром")]
    [Range(0.0, double.MaxValue, ErrorMessage = "Актуальная цена должна быть положительным значением")]
    public decimal ActualPrice { get; set; }

    [Column(name: "user_account_id")]
    [Required]
    public int UserAccountId { get; set; }

    [Column(name: "room_id")]
    [Required]
    public int RoomId { get; set; }

    public virtual ICollection<PaymentRoom> PaymentRooms { get; set; } = new List<PaymentRoom>();

    public virtual Room Room { get; set; } = null!;

    public virtual UserAccount UserAccount { get; set; } = null!;
}
*/