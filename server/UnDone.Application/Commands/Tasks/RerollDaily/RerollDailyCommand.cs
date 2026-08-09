using MediatR;

namespace UnDone.Application.Commands.Tasks.RerollDaily;

public record RerollDailyCommand(
    Guid TaskId,
    Guid UserId
) : IRequest<RerollDailyResult>;

public record RerollDailyResult(
    Guid TaskId,
    String NewTitle
);