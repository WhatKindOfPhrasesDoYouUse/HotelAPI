using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelAPI.Models;

[Table(name: "card", Schema = "core")]
public partial class Card
{
    [Column(name: "id")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [Column(name: "name")]
    [Required(ErrorMessage = "Поле названия банка является обязательным параметром")]
    [StringLength(30, MinimumLength = 1, ErrorMessage = "Поле названия банка должно содержать от 1 до 30 символов")]
    [RegularExpression(@"^[A-Za-zА-Яа-я]+$", ErrorMessage = "Название банка должно содержать только буквы")]
    public string Name { get; set; } = null!;

    [Column(name: "number")]
    [Required(ErrorMessage = "Поле номера карты является обязательным параметром")]
    [StringLength(16, MinimumLength = 16, ErrorMessage = "Поле номера карты должно содержать строго 16 символов")]
    [RegularExpression(@"^[0-9]{16}$", ErrorMessage = "Номер карты должен состоять из 16 цифр")]
    public string Number { get; set; } = null!;

    [Column(name: "date")]
    [Required(ErrorMessage = "Поле даты действия карты является обязательным параметром")]
    [StringLength(5, MinimumLength = 5, ErrorMessage = "Поле даты действия карты должно содержать строго 5 символов")]
    [RegularExpression(@"^(0[1-9]|1[0-2])/[0-9]{2}$", ErrorMessage = "Дата должна быть в формате MM/YY")]
    public string Date { get; set; } = null!;

    //public virtual ICollection<UserAccount> UserAccounts { get; set; } = new List<UserAccount>();
}
