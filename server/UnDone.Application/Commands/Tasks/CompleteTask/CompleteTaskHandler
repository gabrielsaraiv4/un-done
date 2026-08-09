using MediatR;
using UnDone.Application.Interfaces;
using UnDone.Domain.Enums;

namespace UnDone.Application.Commands.Tasks.CompleteTask;

public class CompleteTaskHandler : IRequestHandler<CompleteTaskCommand, CompleteTaskResult>
{
    private readonly ITaskRepository _taskRepository;
    private readonly IUserRepository _userRepository;

    public CompleteTaskHandler(ITaskRepository taskRepository, IUserRepository userRepository)
    {
        _taskRepository = taskRepository;
        _userRepository = userRepository;
    }

    public async Task<CompleteTaskResult> Handle(CompleteTaskCommand request, CancellationToken cancellationToken)
    {
        var task = await _taskRepository.GetByIdAsync(request.TaskId)
            ?? throw new InvalidOperationException("Task not found.");

        if (task.UserId != request.UserId)
            throw new UnauthorizedAccessException("This task does not belong to the current user.");

        if (task.IsCompleted)
            throw new InvalidOperationException("Task is already completed.");

        var user = await _userRepository.GetByIdAsync(request.UserId)
            ?? throw new InvalidOperationException("User not found.");

        var xp = task.XpReward;
        var coins = task.CoinReward;

        // XP Boost if active
        var boost = user.ActiveEffects
            .FirstOrDefault(e => e.EffectType == EffectType.XpBoost && e.ExpiresAt > DateTime.UtcNow);
        
        if (boost is not null)
            xp *= 2;

        task.IsCompleted = true;
        task.CompletedAt = DateTime.UtcNow;

        if (task.Type == TaskType.Daily)
            task.LastResetDate = DateOnly.FromDateTime(DateTime.UtcNow);
        
        user.CurrentXp += xp;
        user.Coins += coins;
        user.LastActivityDate = DateOnly.FromDateTime(DateTime.UtcNow);
        user.Level = CalculateLevel(user.CurrentXp);

        await _taskRepository.UpdateAsync(task);
        await _userRepository.UpdateAsync(user);

        return new CompleteTaskResult(task.Id, xp, coins, user.Level, user.CurrentXp, user.Coins);
    }

    private static int CalculateLevel(int totalXP)
    {
        int level = 1;
        int xpRequired = 100;

        while (totalXP >= xpRequired)
        {
            totalXP -= xpRequired;
            level++;
            xpRequired = 100 + ((level - 1) * 50);
        }

        return level;
    }
}