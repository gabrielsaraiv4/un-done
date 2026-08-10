using UnDone.Domain.Enums;

namespace UnDone.Domain.Entities;

/// <summary>
/// Represents an item definition available in the store.
/// Consumable items map to an EffectType applied via ActiveEffect on purchase.
/// Cosmetic items are permanent unlocks tracked via UserItem.
/// </summary>
public class ShopItem
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public ShopItemType Type { get; set; }

    public EffectType? EffectType { get; set; }

    public int? EffectDurationHours { get; set; }

    public int Cost { get; set; }

    public bool IsActive { get; set; } = true;

    // Navigation properties
    public ICollection<UserItem> UserItems { get; set; } = new List<UserItem>();
}