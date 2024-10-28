using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelAPI.Models
{
    [Table(name: "user_account", Schema = "core")]
    public class UserAccount
    {
        // TODO: добавить fk от корзины когда она появится в проекте 

        [Column(name: "id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column(name: "first_name")]
        [Required(ErrorMessage = "Поле имя пользователя является обязательным параметром")]
        [StringLength(30, ErrorMessage = "Поле имя пользователя должно иметь строковое значение, не превышающее 30 символов")]
        public string FirstName { get; set; }

        [Column(name: "last_name")]
        [Required(ErrorMessage = "Поле фамилия пользователя является обязательным параметром")]
        [StringLength(30, ErrorMessage = "Поле фамилия пользователя должно иметь строковое значение, не превышающее 30 символов")]
        public string LastName { get; set; }

        [Column(name: "surname")]
        [StringLength(30, ErrorMessage = "Поле отчество пользователя должно иметь строковое значение, не превышающее 30 символов")]
        public string Surname { get; set; }

        [Column(name: "email")]
        [Required(ErrorMessage = "Поле электронная почта пользователя является обязательным параметром")]
        [StringLength(50, ErrorMessage = "Поле электронная почта пользователя должно иметь строковое значение, не превышающее 50 символов")]
        public string Email { get; set; }

        [Column(name: "phone_number")]
        [Required(ErrorMessage = "Поле номер телефона пользователя является обязательным параметром")]
        [StringLength(12, MinimumLength = 12, ErrorMessage = "Номер телефона должен содержать строго 12 символов")]
        public string PhoneNumber { get; set; }

        [Column(name: "password")]
        [Required(ErrorMessage = "Поле пароль пользователя является обязательным параметром")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Пароль должен содержать от 5 до 50 символов")]
        public string Password { get; set; }

        [Column(name: "passport")]
        [Required(ErrorMessage = "Поле паспортных данных является обязательным параметром")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Паспортные данные должны содержать строго 10 символов")]
        public string Passport { get; set; }
    }
}
