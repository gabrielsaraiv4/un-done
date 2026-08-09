using MediatR;
using UnDone.Application.Interfaces;
using UnDone.Domain.Entities;
using UnDone.Domain.Enums;

namespace UnDone.Application.Commands.Tasks.CreateTask;

public class CreateTaskHandler : IRequestHandler<CreateTaskCommand, CreateTaskResult>
{
    private readonly ITaskRepository _taskRepository;

    public CreateTaskHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<CreateTaskResult> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        var (xp, coins) = request.Type == TaskType.Daily
            ? (15, 2)
            : GetRewards(request.Difficulty);

        var task = new TaskItem
        {
            Id = Guid.NewGuid(),
            UserId = request.UserId,
            Title = request.Title,
            Description = request.Description,
            Type = request.Type,
            Difficulty = request.Difficulty,
            XpReward = xp,
            CoinReward = coins,
            LastResetDate = request.Type == TaskType.Daily ? DateOnly.FromDateTime(DateTime.UtcNow) : null
        };

        await _taskRepository.AddAsync(task);

        return new CreateTaskResult(task.Id, task.Title, task.Type, task.Difficulty, task.XpReward, task.CoinReward);
    }

    private static (int xp, int coins) GetRewards(TaskDifficulty difficulty) => difficulty switch
    {
        TaskDifficulty.Easy => (10, 1),
        TaskDifficulty.Medium => (20, 2),
        TaskDifficulty.Hard => (30, 3),
        _ => throw new InvalidOperationException("Invalid difficulty.")
    };
}