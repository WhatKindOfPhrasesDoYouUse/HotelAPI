using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelAPI.Models
{
    [Table(name: "card", Schema = "core")]
    public class Card
    {
        [Column(name: "id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column(name: "name")]
        [Required(ErrorMessage = "Поле имя является обязательным")]
        [StringLength(30, ErrorMessage = "Поле имя должно иметь строковое значение, не превышающее 30 символов")]
        public string Name { get; set; }

        [Column(name: "number")]
        [Required(ErrorMessage = "Поле номера карты является обязательным")]
        [StringLength(16, MinimumLength = 16, ErrorMessage = "Номер карты должен содержать строго 16 символов")]
        public string Number { get; set; }

        [Column(name: "date")]
        [Required(ErrorMessage = "Поле даты является обязательным")]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "Дата окончания карты должна содержать строго 5 символов")]
        public string Date { get; set; }

    }
}
