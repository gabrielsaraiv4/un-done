using Microsoft.EntityFrameworkCore;
using UnDone.Application.Interfaces;
using UnDone.Domain.Entities;
using UnDone.Domain.Enums;
using UnDone.Infrastructure.Data;

namespace UnDone.Infrastructure.Repositories;

public class StoreRepository : IStoreRepository
{
    private readonly AppDbContext _context;

    public StoreRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ShopItem?> GetByIdAsync(Guid id)
    {
        return await _context.ShopItems.FindAsync(id);
    }

    public async Task<IEnumerable<ShopItem>> GetAllActiveAsync()
    {
        return await _context.ShopItems
            .Where(s => s.IsActive)
            .ToListAsync();
    }

    public async Task<UserItem> AddUserItemAsync(UserItem userItem)
    {
        await _context.UserItems.AddAsync(userItem);
        await _context.SaveChangesAsync();
        return userItem;
    }

    public async Task<ActiveEffect?> GetActiveEffectAsync(Guid userId, EffectType effectType)
    {
        return await _context.ActiveEffects
            .Where(ae => ae.UserId == userId && ae.Type == effectType && ae.ExpiresAt > DateTime.UtcNow)
            .FirstOrDefaultAsync();
    }

    public async Task AddActiveEffectAsync(ActiveEffect effect)
    {
        await _context.ActiveEffects.AddAsync(effect);
        await _context.SaveChangesAsync();
    }
}