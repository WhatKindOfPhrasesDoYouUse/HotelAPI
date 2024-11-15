/*using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelAPI.Models;

// TODO: Добавить время отправления и прибытия

[Table(name: "travel", Schema = "core")]
public partial class Travel
{
    [Column(name: "id")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column(name: "name")]
    [Required(ErrorMessage = "Поле названия путевки является обязательным параметром")]
    [StringLength(30, MinimumLength = 1, ErrorMessage = "Поле названия путевки должно содержать от 1 до 30 символов")]
    [RegularExpression(@"^[A-Za-zА-Яа-я]+$", ErrorMessage = "Название путевки должно содержать только буквы")]
    public string Name { get; set; } = null!;

    [Column(name: "description")]
    public string? Description { get; set; }

    [Column(name: "price")]
    [Required(ErrorMessage = "Поле цены является обязательным параметром")]
    [Range(0.0, double.MaxValue, ErrorMessage = "Цена должна быть положительным числом")]
    public decimal Price { get; set; }

    [Column(name: "departure_date")]
    [Required(ErrorMessage = "Дата отьезда является обязательным параметром")]

    public DateOnly DepartureDate { get; set; }

    [Column(name: "arrival_date")]
    [Required(ErrorMessage = "Дата прибытия является обязательным параметром")]
    public DateOnly ArrivalDate { get; set; }

    [Column(name: "hotel_id")]
    [Required]
    public int HotelId { get; set; }

    public virtual Hotel Hotel { get; set; } = null!;

    public virtual ICollection<PaymentTravel> PaymentTravels { get; set; } = new List<PaymentTravel>();

    public virtual ICollection<TravelReview> TravelReviews { get; set; } = new List<TravelReview>();
}
*/