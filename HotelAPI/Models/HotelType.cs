using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelAPI.Models;

[Table(name: "hotel_type", Schema = "core")]
public partial class HotelType
{
    [Column(name: "id")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column(name: "name")]
    [Required(ErrorMessage = "Поле названия роли является обязательным параметром")]
    [StringLength(30, MinimumLength = 1, ErrorMessage = "Поле названия роли должно содержать от 1 до 30 символов")]
    [RegularExpression(@"^[A-Za-zА-Яа-я]+$", ErrorMessage = "Название роли должно содержать только буквы")]
    public string Name { get; set; } = null!;

    [Column(name: "description")]
    public string? Description { get; set; }

    public virtual ICollection<Hotel> Hotels { get; set; } = new List<Hotel>();
}
