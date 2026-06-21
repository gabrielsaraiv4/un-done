using UnDone.Domain.Enums;

namespace UnDone.Domain.Entities;

/// <summary>
/// Represents a task created by the user. Can be a one-shot take (Easy, Medium or Hard)
/// or a Daily task that resets automatically every day.
/// </summary>

public class TaskItem
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }

    public TaskType Type { get; set; }
    public TaskDifficulty Difficulty { get; set; }

    public bool IsCompleted { get; set; } = false;
    public DateTime? CompletedAt { get; set; }

    // For daily tasks: tracks the lastdate this task was reset/completed,
    // used by the lazy renewal check on login.

    public DateOnly? LastResetDate { get; set; }

    public int XpReward { get; set; }
    public int CoinReward { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}