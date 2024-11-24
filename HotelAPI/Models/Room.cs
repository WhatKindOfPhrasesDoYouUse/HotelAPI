using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelAPI.Models;

[Table(name: "room", Schema = "core")]
public partial class Room
{
    [Column(name: "id")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column(name: "room_type")]
    [Required(ErrorMessage = "Тип комнаты является обязательным параметром")]
    [StringLength(30, MinimumLength = 1, ErrorMessage = "Название типа комнаты должно быть от 1 до 30 символов")]
    public string RoomType { get; set; } = null!;

    [Column(name: "room_number")]
    [Required(ErrorMessage = "Номер комнаты является обязатеьным параметром")]
    [Range(0, int.MaxValue, ErrorMessage = "Номер комнаты должен быть положительным числом")]
    public int RoomNumber { get; set; }

    [Column(name: "capacity")]
    [Required(ErrorMessage = "Вместительность комнаты является обязательным параметром")]
    [Range(0, int.MaxValue, ErrorMessage = "Вместительность комнаты должно быть положитеьным числом")]
    public int Capacity { get; set; }

    [Column(name: "description")]
    public string? Description { get; set; }

    [Column(name: "price")]
    [Required(ErrorMessage = "Поле цены является обязательным параметром")]
    [Range(0, double.MaxValue, ErrorMessage = "Поле цены должно быть положительным числом")]
    public decimal Price { get; set; }

    [Column(name: "hotel_id")]
    [Required]
    public int HotelId { get; set; }

    public virtual Hotel Hotel { get; set; } = null!;

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<RoomComfort> Comforts { get; set; } = new List<RoomComfort>();
}
