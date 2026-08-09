using MediatR;
using UnDone.Domain.Enums;

namespace UnDone.Application.Commands.Tasks.CreateTask;

public record CreateTaskCommand(
    Guid UserId,
    string Title,
    string? Description,
    TaskType Type,
    TaskDifficulty Difficulty
) : IRequest<CreateTaskResult>;

public record CreateTaskResult(
    Guid TaskId,
    string Title,
    TaskType Type,
    TaskDifficulty Difficulty,
    int XpReward,
    int CoinReward
);