/*using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelAPI.Models;

[Table(name: "hotel_review", Schema = "core")]
public partial class HotelReview
{
    [Column(name: "id")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column(name: "comment")]
    [Required(ErrorMessage = "Поле комментария является обязательным параметром")]
    public string Comment { get; set; } = null!;

    [Column(name: "publish_date")]
    [Required(ErrorMessage = "Поле даты комментария является обязательным параметром")]
    public DateOnly PublishDate { get; set; }

    [Column(name: "rating")]
    [Required(ErrorMessage = "Поле рейтинга является обязательным параметром")]
    [Range(1, maximum: 5, ErrorMessage = "Рейтинг отеля должен быть в промежутке между 1 и 5")]
    public int Rating { get; set; }

    [Column(name: "hotel_id")]
    [Required]
    public int HotelId { get; set; }

    [Column(name: "user_account_id")]
    [Required]
    public int UserAccountId { get; set; }

    public virtual Hotel Hotel { get; set; } = null!;

    public virtual UserAccount UserAccount { get; set; } = null!;
}
*/