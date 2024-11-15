/*using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelAPI.Models;

[Table(name: "role", Schema = "core")]
public partial class Role
{
    [Column(name: "id")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column(name: "name")]
    [Required(ErrorMessage = "Поле названия рои является обязательным параметром")]
    [StringLength(30, MinimumLength = 1, ErrorMessage = "Поле названия роли должно содержать от 1 до 30 символов")]
    [RegularExpression(@"^[A-Za-zА-Яа-я]+$", ErrorMessage = "Название роли должно содержать только буквы")]
    public string Name { get; set; } = null!;

    public virtual ICollection<UserRole> UserAccounts { get; set; } = new List<UserRole>();
}
*/