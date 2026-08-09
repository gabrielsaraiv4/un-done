using MediatR;

namespace UnDone.Application.Commands.Tasks.DeleteTask;

public record DeleteTaskCommand(
    Guid TaskId,
    Guid UserId
): IRequest<Unit>;