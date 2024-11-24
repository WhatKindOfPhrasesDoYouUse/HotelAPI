using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelAPI.Models;

[Table(name: "service", Schema = "core")]
public partial class Serv
{
    [Column(name: "id")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column(name: "name")]
    [Required(ErrorMessage = "Поле названия сервиса является обязательным параметром")]
    [StringLength(30, MinimumLength = 1, ErrorMessage = "Поле названия сервиса должно содержать от 1 до 30 символов")]
    [RegularExpression(@"^[A-Za-zА-Яа-я]+$", ErrorMessage = "Название сервиса должно содержать только буквы")]
    public string Name { get; set; } = null!;

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

    public virtual ICollection<RequestServ> RequestServices { get; set; } = new List<RequestServ>();
}
