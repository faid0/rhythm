using System.ComponentModel.DataAnnotations;

namespace Rhythm.Web.Models;

public enum HabitFrequency
{
    Daily,
    Weekly,
    Monthly
}

public class Habit
{
    public int Id { get; set; }

    [Required]
    [MaxLength(450)]
    public string UserId { get; set; } = string.Empty;

    [Required]
    [MaxLength(120)]
    public string Title { get; set; } = string.Empty;

    [MaxLength(2000)]
    public string? Description { get; set; }

    public HabitFrequency Frequency { get; set; }

    public DateOnly StartDate { get; set; }

    public int SortOrder { get; set; }

    public DateTimeOffset CreatedAtUtc { get; set; }
        = DateTimeOffset.UtcNow;

    public DateTimeOffset? ArchivedAtUtc { get; set; }

    public ICollection<HabitPeriod> Periods { get; set; }
        = new List<HabitPeriod>();
}