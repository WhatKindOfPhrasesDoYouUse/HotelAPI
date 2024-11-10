using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelAPI.Models;

// Поменять цену на double в бд

[Table(name: "payment_travel", Schema = "core")]
public partial class PaymentTravel
{
    [Column(name: "id")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column(name: "price")]
    [Required(ErrorMessage = "Поле цены является обязательным")]
    [Range(0, double.MaxValue, ErrorMessage = "Цена должна быть положительной")]
    public int Price { get; set; }

    [Column(name: "payment_status")]
    [Required(ErrorMessage = "Статуст оплаты является обязательным")]
    [StringLength(30, MinimumLength = 1, ErrorMessage = "Статуст оплаты должен содержать от 1 до 30 символов")]
    public string PaymentStatus { get; set; } = null!;

    [Column(name: "payment_date")]
    [Required(ErrorMessage = "Дата оплаты является обязательной")]
    public DateOnly PaymentDate { get; set; }

    [Column(name: "travel_id")]
    [Required]
    public int TravelId { get; set; }

    [Column(name: "user_account_id")]
    [Required]
    public int UserAccountId { get; set; }

    public virtual Travel Travel { get; set; } = null!;

    public virtual UserAccount UserAccount { get; set; } = null!;
}
