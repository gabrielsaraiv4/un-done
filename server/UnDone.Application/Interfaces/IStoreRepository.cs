using UnDone.Domain.Enums;
using UnDone.Domain.Entities;

namespace UnDone.Application.Interfaces;

public interface IStoreRepository
{
    Task<ShopItem?> GetByIdAsync(Guid id);
    Task<IEnumerable<ShopItem>> GetAllActiveAsync();
    Task<UserItem> AddUserItemAsync(UserItem userItem);
    Task<ActiveEffect?> GetActiveEffectAsync(Guid userId, EffectType effectType);
    Task AddActiveEffectAsync(ActiveEffect effect);
}