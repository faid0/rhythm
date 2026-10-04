using System.ComponentModel.DataAnnotations;

namespace Rhythm.Web.Models;

public class UserSettings
{
    [Key]
    [MaxLength(450)]
    public string UserId { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string TimeZoneId { get; set; } = "UTC";

    public DayOfWeek WeekStartsOn { get; set; } = DayOfWeek.Monday;
}