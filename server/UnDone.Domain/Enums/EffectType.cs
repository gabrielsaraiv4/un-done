namespace Undone.Domain.Enums;

/// <summary>
/// 1. Defines the type of a temporary active on a user.
/// 1.1. New consumable effects added to the store should extend this enum
/// rather than requiring new fields on the User entity.
/// </summary>

public enum EffectType
{
    XpBoost = 0,
    DayOff = 1
}
