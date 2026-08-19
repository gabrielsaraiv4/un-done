using MediatR;

namespace UnDone.Application.Commands.Store.PurchaseItem;

public record PurchaseItemCommand(
    Guid UserId,
    Guid ItemId
) : IRequest<PurchaseItemResult>;

public record PurchaseItemResult(
    Guid ItemId,
    string ItemName,
    int RemainingCoins
);