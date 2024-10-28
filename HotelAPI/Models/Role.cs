using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelAPI.Models
{
    [Table(name: "role", Schema = "core")]
    public class Role
    {
        [Column(name: "id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column(name: "name")]
        [Required(ErrorMessage = "Поле имя роли является обязательным параметром")]
        [StringLength(30, ErrorMessage = "Поле имя роли должно иметь строковое значение, не превышающее 30 символов")]
        public string Name { get; set; }
    }
}
