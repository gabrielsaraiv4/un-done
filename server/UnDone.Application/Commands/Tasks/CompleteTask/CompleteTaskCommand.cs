using MediatR;

namespace UnDone.Application.Commands.Tasks.CompleteTask;

public record CompleteTaskCommand(
    Guid TaskId,
    Guid UserId
) : IRequest<CompleteTaskResult>;

public record CompleteTaskResult(
    Guid TaskId,
    int XpEarned,
    int CoinsEarned,
    int NewLevel,
    int NewXp,
    int NewCoins
);