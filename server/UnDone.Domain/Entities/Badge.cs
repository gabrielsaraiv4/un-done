using UnDone.Domain.Enums;

namespace UnDone.Domain.Entities;

/// <summary>
/// 1. Represents a badge definition available in the system.
///     1.1. Badges are granted automatically by the BadgeService when a user's stats satisfy
///     ConditionType + ConditionValue, allowing new badgesto be added data/seed without
///     requiring new application code.
/// </summary>

public class Badge
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string IconUrl { get; set; } = string.Empty;

    public BadgeConditionType conditionType { get; set; }
    public int ConditionValue { get; set; }

    //Navigation properties
    public ICollection<UserBadge> UserBadges { get; set; } = new List<UserBadge>();
}