using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelAPI.Models;

[Table(name: "comfort", Schema = "core")]
public partial class Comfort
{
    [Column(name: "id")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column(name: "name")]
    [Required(ErrorMessage = "Поле названия услуги комфорта комнаты является обязательным параметром")]
    [StringLength(30, MinimumLength = 1, ErrorMessage = "Поле названия услуги комфорта комнаты должно содержать от 1 до 30 символов")]
    [RegularExpression(@"^[A-Za-zА-Яа-я]+$", ErrorMessage = "Название услуги комфорта комнаты должно содержать только буквы")]
    public string Name { get; set; } = null!;

    [Column(name: "description")]
    public string? Description { get; set; }
}
