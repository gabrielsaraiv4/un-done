namespace UnDone.Domain.Enums;

/// <summary>
/// 1. Defines the type of condition a badge requires to be earned.
///     1.1. The BadgeService evaluates the user's current stats against the badge's
///     ConditionValue based on this type, allowing new badges to be added via
///     data rather than new code.
/// </summary>

public enum BadgeConditionType
{
    StreakDays = 0,
    TasksCompleted = 1,
    HardTasksCompleted = 2,
    TaskesCompletedInSingleDay = 3,
    LevelReached = 4
}