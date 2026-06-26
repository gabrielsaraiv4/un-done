using Undone.Domain.Enums;
using UnDone.Domain.Enums;

namespace UnDone.Domain.Entities;

/// <summary>
/// 1. Represents an item definition available in the store.
///     1.1. Consumable items map to an <see cref="EffectType"/> applied via ActiveEffect on ourchase.
///     1.2. Cosmetic items are permanent unlocks tracked via UserItem.
/// </summary>

 public class ShopItem
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public EffectType? EffectType { get; set; }

    public int Cost { get; set; }

    public bool isActive { get; set; } = true;

    // Navigation properties
    public ICollection<UserItem> UserItems { get; set; } = new List<UserItem>();
}