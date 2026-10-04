using System.ComponentModel.DataAnnotations;

namespace Rhythm.Web.Models;

public class HabitPeriod
{
    public int Id { get; set; }

    public int HabitId { get; set; }

    public Habit Habit { get; set; } = null!;

    public DateOnly PeriodStart { get; set; }

    public DateTimeOffset? CompletedAtUtc { get; set; }

    [Range(1, 5)]
    public int? QualityRating { get; set; }

    [MaxLength(4000)]
    public string? ImprovementNote { get; set; }
}