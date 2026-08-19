using MediatR;

namespace UnDone.Application.Queries.Store.GetStoreItems;

public record GetStoreItemsQuery : IRequest<IEnumerable<StoreItemResponse>>;

public record StoreItemResponse(
    Guid Id,
    string Name,
    string Description,
    int Cost
);