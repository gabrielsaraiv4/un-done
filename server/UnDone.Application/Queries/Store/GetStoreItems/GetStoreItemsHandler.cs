using MediatR;
using UnDone.Application.Interfaces;

namespace UnDone.Application.Queries.Store.GetStoreItems;

public class GetStoreItemsHandler : IRequestHandler<GetStoreItemsQuery, IEnumerable<StoreItemResponse>>
{
    private readonly IStoreRepository _storeRepository;

    public GetStoreItemsHandler(IStoreRepository storeRepository)
    {
        _storeRepository = storeRepository;
    }

    public async Task<IEnumerable<StoreItemResponse>> Handle(GetStoreItemsQuery request, CancellationToken cancellationToken)
    {
        var items = await _storeRepository.GetAllActiveAsync();

        return items.Select(i => new StoreItemResponse(
            i.Id,
            i.Name,
            i.Description,
            i.Cost
        ));
    }
}