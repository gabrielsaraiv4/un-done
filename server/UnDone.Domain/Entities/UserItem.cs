namespace UnDone.Domain.Entities;

/// <summary>
/// 1. Join entity recording, which shop items a user has purchased and when.
///     1.1. For Cosmetic items, presence os a record means the item is permanently unlocked.
///     1.2. For Consumable items, this serve as a purchase history/log.
/// </summary>

public class UserItem
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public Guid ShopItemId { get; set; }
    public ShopItem ShopItem { get; set; } = null!;

    public DateTime PurchasedAt { get; set; } = DateTime.UtcNow;
}