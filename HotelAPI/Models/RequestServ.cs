using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HotelAPI.Models;

[Table(name: "request_service", Schema = "core")]
public partial class RequestServ
{
    [Column(name: "id")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [Column(name: "request_date")]
    [Required(ErrorMessage = "Дата запроса является обязательным параметром")]
    public DateOnly RequestDate { get; set; }

    [Column(name: "request_time")]
    [Required(ErrorMessage = "Время запроса является обязательным параметром")]
    public TimeOnly RequestTime { get; set; }

    [Column(name: "request_status")]
    [Required(ErrorMessage = "Статуст услуги является обязательным параметром")]
    [StringLength(30, MinimumLength = 1, ErrorMessage = "Статуст должен содержать от 1 до 30 символов")]
    public string RequestStatus { get; set; } = null!;

    [Column(name: "additional_notes")]
    public string? AdditionalNotes { get; set; }

    [Column(name: "quantity_requests")]
    [Required(ErrorMessage = "Количество запросов является обязательным параметром")]
    [Range(1, int.MaxValue, ErrorMessage = "Количество запросов на обслуживание должно быть равно или более 1")]
    public int QuantityRequests { get; set; }

    [Column(name: "service_id")]
    [Required]
    public long ServiceId { get; set; }

    [Column(name: "user_account_id")]
    [Required]
    public long UserAccountId { get; set; }
    public virtual Serv Service { get; set; } = null!;
    public virtual UserAccount UserAccount { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<RequestServReview> RequestServiceReviews { get; set; } = new List<RequestServReview>();
}
