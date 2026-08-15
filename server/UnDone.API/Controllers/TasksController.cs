using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UnDone.Application.Commands.Tasks.CompleteTask;
using UnDone.Application.Commands.Tasks.CreateTask;
using UnDone.Application.Commands.Tasks.DeleteTask;
using UnDone.Application.Commands.Tasks.RerollDaily;
using UnDone.Application.Queries.Tasks.GetTasks;

namespace UnDone.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TasksController : ControllerBase
{
    private readonly IMediator _mediator;

    public TasksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private Guid GetUserId() =>
        Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

    [HttpGet]
    public async Task<IActionResult> GetTasks()
    {
        var result = await _mediator.Send(new GetTasksQuery(GetUserId()));
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTask([FromBody] CreateTaskRequest request)
    {
        var command = new CreateTaskCommand(
            GetUserId(),
            request.Title,
            request.Description,
            request.Type,
            request.Difficulty
        );
        return Ok(await _mediator.Send(command));
    }

    [HttpPost("{taskId}/complete")]
    public async Task<IActionResult> CompleteTask(Guid taskId)
    {
        var result = await _mediator.Send(new CompleteTaskCommand(taskId, GetUserId()));
        return Ok(result);
    }

    [HttpDelete("{taskId}")]
    public async Task<IActionResult> DeleteTask(Guid taskId)
    {
        await _mediator.Send(new DeleteTaskCommand(taskId, GetUserId()));
        return NoContent();
    }

    [HttpPost("{taskId}/reroll")]
    public async Task<IActionResult> RerollDaily(Guid taskId)
    {
        var result = await _mediator.Send(new RerollDailyCommand(taskId, GetUserId()));
        return Ok(result);
    }
}