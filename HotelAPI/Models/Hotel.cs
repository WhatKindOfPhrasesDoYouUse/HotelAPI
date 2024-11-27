using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HotelAPI.Models;

[Table(name: "hotel", Schema = "core")]
public partial class Hotel
{
    [Column(name: "id")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [Column(name: "name")]
    [Required(ErrorMessage = "Поле названия отеля является обязательным параметром")]
    [StringLength(30, MinimumLength = 1, ErrorMessage = "Поле названия отеля должно содержать от 1 до 30 символов")]
    [RegularExpression(@"^[A-Za-zА-Яа-я]+$", ErrorMessage = "Название отеля должно содержать только буквы")]
    public string Name { get; set; } = null!;

    [Column(name: "address")]
    [Required(ErrorMessage = "Поле адрес является обязательным параметром")]
    [StringLength(30, MinimumLength = 1, ErrorMessage = "Поле адрес должно содержать от 1 до 30 символов")]
    [RegularExpression(@"^[A-Za-zА-Яа-я]+$", ErrorMessage = "Название адреса должно содержать только буквы")]
    public string Address { get; set; } = null!;

    [Column(name: "city")]
    [Required(ErrorMessage = "Поле город является обязательным параметром")]
    [StringLength(30, MinimumLength = 1, ErrorMessage = "Поле город должно содержать от 1 до 30 символов")]
    [RegularExpression(@"^[A-Za-zА-Яа-я]+$", ErrorMessage = "Название город должно содержать только буквы")]
    public string City { get; set; } = null!;

    [Column(name: "description")]
    public string? Description { get; set; }

    [Column(name: "phone_number")]
    [Required(ErrorMessage = "Поле телефонного номера отеля является обязательным параметром")]
    [StringLength(12, MinimumLength = 12, ErrorMessage = "Поле телефонного номера отеля должно содержать строго 12 символов")]
    [RegularExpression(@"^\+[0-9]{11}$", ErrorMessage = "Телефонный номер должен начинаться с + и содержать строго 12 цифр")]
    public string PhoneNumber { get; set; } = null!;

    [Column(name: "email")]
    [Required(ErrorMessage = "Поле электронной почты является обязательным параметром")]
    [StringLength(50, ErrorMessage = "Поле электронной почты должно содержать не более 50 символов")]
    [RegularExpression(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$", ErrorMessage = "Введите корректный адрес электронной почты.")]
    public string Email { get; set; } = null!;

    [Column(name: "construction_year")]
    public DateOnly? ConstructionYear { get; set; }

    [Column(name: "rating")]
    [Range(1, maximum: 5, ErrorMessage = "Рейтинг отеля должен быть в промежутке между 1 и 5")]
    public int? Rating { get; set; }

    [Column(name: "manager_id")]
    [Required]
    public long ManagerId { get; set; }

    [Column(name: "hotel_type_id")]
    [Required]
    public long HotelTypeId { get; set; }

    public virtual HotelType? HotelType { get; set; } = null!;

    public virtual UserAccount? Manager { get; set; } = null!;

    public virtual ICollection<HotelReview> HotelReviews { get; set; } = new List<HotelReview>();

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();

    public virtual ICollection<Serv> Services { get; set; } = new List<Serv>();

    public virtual ICollection<Travel> Travels { get; set; } = new List<Travel>();
}
