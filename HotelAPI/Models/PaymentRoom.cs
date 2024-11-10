using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelAPI.Models;

// Поменять типы в базе на double, т.к. нельзя чекать decimal на макс. значение

[Table(name: "payment_room", Schema = "core")]
public partial class PaymentRoom
{
    [Column(name: "id")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column(name: "price")]
    [Required(ErrorMessage = "Поле цены является обязательным параметром")]
    [Range(0, double.MaxValue, ErrorMessage = "Цена должна быть положительной")]
    public double Price { get; set; }

    [Column(name: "payment_status")]
    [Required(ErrorMessage = "Статуст оплаты является обязательным параметром")]
    [StringLength(30, MinimumLength = 1, ErrorMessage = "Статуст оплаты должен содержать от 1 до 30 символов")]
    public string PaymentStatus { get; set; } = null!;

    [Column(name: "payment_date")]
    [Required(ErrorMessage = "Дата оплаты является обязательным параметром")]
    public DateOnly PaymentDate { get; set; }

    [Column(name: "booking_id")]
    [Required]
    public int BookingId { get; set; }

    public virtual Booking Booking { get; set; } = null!;
}
