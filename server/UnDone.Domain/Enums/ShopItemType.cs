namespace UnDone.Domain.Enums;

/// <summary>
/// Defines the category of a shop item, used to determine how its effect is
/// applied.
/// </summary>

public enum ShopItemType
{
    Consumable = 0,     //Day-off, XP Boost, etc.
    Cosmetic = 1        //Themes, profile frames, etc.
}