using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelAPI.Models;

[Table(name: "user_account", Schema = "core")]
public partial class UserAccount
{
    [Column(name: "id")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column(name: "email")]
    [Required(ErrorMessage = "Поле электронной почты является обязательным параметром")]
    [StringLength(50, ErrorMessage = "Поле электронной почты должно содержать не более 50 символов")]
    [RegularExpression(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$", ErrorMessage = "Введите корректный адрес электронной почты.")]
    public string Email { get; set; } = null!;

    [Column(name: "phone_number")]
    [Required(ErrorMessage = "Поле телефона пользователя является обязательным параметром")]
    [StringLength(12, MinimumLength = 12, ErrorMessage = "Поле телефонного номера должно содержать строго 12 символов")]
    [RegularExpression(@"^\+[0-9]{11}$", ErrorMessage = "Телефонный номер должен начинаться с + и содержать строго 12 цифр")]
    public string PhoneNumber { get; set; } = null!;

    [Column(name: "password")]
    [Required(ErrorMessage = "Пароль является обязательным")]
    [StringLength(50, MinimumLength = 10, ErrorMessage = "Пароль должен быть длинной от 10 до 50")]
    public string Password { get; set; } = null!;

    [Column(name: "passport")]
    [Required(ErrorMessage = "Паспортные данные являются обязательным параметром")]
    [StringLength(10, MinimumLength = 10, ErrorMessage = "Паспорт должен содержать ровно 10 символов.")]
    [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Номер паспорта должен состоять из 10 цифр.")]
    public string Passport { get; set; } = null!;

    [Column(name: "card_id")]
    [Required]
    public int? CardId { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual Card? Card { get; set; }

    public virtual ICollection<HotelReview> HotelReviews { get; set; } = new List<HotelReview>();

    public virtual ICollection<Hotel> Hotels { get; set; } = new List<Hotel>();

    public virtual ICollection<PaymentTravel> PaymentTravels { get; set; } = new List<PaymentTravel>();

    public virtual ICollection<RequestServiceReview> RequestServiceReviews { get; set; } = new List<RequestServiceReview>();

    public virtual ICollection<RequestService> RequestServiceServices { get; set; } = new List<RequestService>();

    public virtual ICollection<RequestService> RequestServiceUserAccounts { get; set; } = new List<RequestService>();

    public virtual ICollection<TravelReview> TravelReviews { get; set; } = new List<TravelReview>();
}
