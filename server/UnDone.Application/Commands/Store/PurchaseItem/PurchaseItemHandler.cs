using MediatR;
using UnDone.Application.Interfaces;
using UnDone.Domain.Entities;
using UnDone.Domain.Enums;

namespace UnDone.Application.Commands.Store.PurchaseItem;

public class PurchaseItemHandler : IRequestHandler<PurchaseItemCommand, PurchaseItemResult>
{
    private readonly IUserRepository _userRepository;
    private readonly IStoreRepository _storeRepository;

    public PurchaseItemHandler(IUserRepository userRepository, IStoreRepository storeRepository)
    {
        _userRepository = userRepository;
        _storeRepository = storeRepository;
    }

    public async Task<PurchaseItemResult> Handle(PurchaseItemCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdWithEffectsAsync(request.UserId) ?? throw new InvalidOperationException("User not found.");

        var item = await _storeRepository.GetByIdAsync(request.ItemId) ?? throw new InvalidOperationException("Item not found");

        if (!item.IsActive)
        {
            throw new InvalidOperationException("This item is no longer available.");
        }

        if (user.Coins < item.Cost)
        {
            throw new InvalidOperationException("Not enough coins.");
        }

        if (item.EffectType.HasValue)
        {
            var alreadyActive = await _storeRepository.GetActiveEffectAsync(request.UserId, item.EffectType.Value);
            if (alreadyActive != null)
            {
                throw new InvalidOperationException("This effect is already active.");
            }

            var effect = new ActiveEffect
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                Type = item.EffectType.Value,
                ActivatedAt = DateTime.UtcNow,
                ExpiresAt = DateTime.UtcNow.AddHours(item.EffectDurationHours ?? 24)
            };

            await _storeRepository.AddActiveEffectAsync(effect);
        }

        user.Coins -= item.Cost;

        await _userRepository.UpdateAsync(user);
        await _storeRepository.AddUserItemAsync(new UserItem
        {
           Id = Guid.NewGuid(),
           UserId= request.UserId,
           ShopItemId = item.Id,
           PurchasedAt = DateTime.UtcNow 
        });

        return new  PurchaseItemResult(item.Id, item.Name, user.Coins);
    }
}