using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelAPI.Models;

[Table(name: "service", Schema = "core")]
public partial class Service
{
    [Column(name: "id")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

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
}
