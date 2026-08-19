using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UnDone.Application.Commands.Store.PurchaseItem;
using UnDone.Application.Queries.Store.GetStoreItems;

namespace UnDone.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class StoreController : ControllerBase
{
    private readonly IMediator _mediator;

    public StoreController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private Guid GetUserId() =>
        Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

    [HttpGet]
    public async Task<IActionResult> GetStoreItems()
    {
        var result = await _mediator.Send(new GetStoreItemsQuery());
        return Ok(result);
    }

    [HttpPost("{itemId}/purchase")]
    public async Task<IActionResult> PurchaseItem(Guid itemId)
    {
        var result = await _mediator.Send(new PurchaseItemCommand(GetUserId(), itemId));
        return Ok(result);
    }
}