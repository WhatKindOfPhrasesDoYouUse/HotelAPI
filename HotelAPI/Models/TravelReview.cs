using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelAPI.Models;

[Table(name: "travel_review", Schema = "core")]
public partial class TravelReview
{
    [Column(name: "id")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [Column(name: "comment")]
    [Required(ErrorMessage = "Поле комментарий является обязательным параметром")]
    public string Comment { get; set; } = null!;

    [Column(name: "publish_date")]
    [Required(ErrorMessage = "Поле даты оставленного комментария является обязательным параметром")]
    public DateOnly PublishDate { get; set; }

    [Column(name: "travel_id")]
    [Required]
    public long TravelId { get; set; }

    [Column(name: "rating")]
    [Required(ErrorMessage = "Поле оставленного рейтинга является обязательным параметром")]
    [Range(1, maximum: 5, ErrorMessage = "Рейтинг путевки должен быть в промежутке между 1 и 5")]
    public int Rating { get; set; }

    [Column(name: "user_account_id")]
    [Required]
    public long UserAccountId { get; set; }

    public virtual Travel Travel { get; set; } = null!;

    public virtual UserAccount UserAccount { get; set; } = null!;
}
