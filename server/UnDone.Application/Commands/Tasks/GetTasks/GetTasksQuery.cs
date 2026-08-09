using MediatR;
using UnDone.Domain.Enums;

namespace UnDone.Application.Queries.Tasks.GetTasks;

public record GetTasksQuery(
    Guid UserId
) : IRequest<IEnumerable<TaskResponse>>;

public record TaskResponse(
    Guid Id,
    string Title,
    string? Description,
    TaskType Type,
    TaskDifficulty Difficulty,
    bool IsCompleted,
    int XpReward,
    int CoinReward,
    DateTime CreatedAt
);