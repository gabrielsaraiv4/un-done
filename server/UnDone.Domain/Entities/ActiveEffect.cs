using Undone.Domain.Enums;

namespace UnDone.Domain.Entities;

/// <summary>
/// Represents a temporary effect currently active for a user, originated from a store purchase
/// (XP Boost, Day-off, etc.). Designed to scale: new effects ypes only require a new EffectType
/// value instead of a schema change.
/// </summary>

public class ActiveEffect
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public EffectType EffectType { get; set; }

    public DateTime ActivatedAt { get; set; } = DateTime.UtcNow;
    public DateTime ExpiresAt { get; set; }
}