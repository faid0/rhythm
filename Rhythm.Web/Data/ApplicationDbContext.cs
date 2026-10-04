using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Rhythm.Web.Models;

namespace Rhythm.Web.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
{
    public DbSet<Habit> Habits => Set<Habit>();

    public DbSet<HabitPeriod> HabitPeriods => Set<HabitPeriod>();

    public DbSet<UserSettings> UserSettings =>
        Set<UserSettings>();
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<HabitPeriod>()
            .HasIndex(x => new { x.HabitId, x.PeriodStart })
            .IsUnique();

        builder.Entity<Habit>()
            .HasMany(x => x.Periods)
            .WithOne(x => x.Habit)
            .HasForeignKey(x => x.HabitId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Habit>()
            .HasIndex(x => new
            {
                x.UserId,
                x.ArchivedAtUtc,
                x.SortOrder
            });
    }
}