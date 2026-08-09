using MediatR;
using UnDone.Application.Interfaces;
using UnDone.Domain.Enums;

namespace UnDone.Application.Commands.Tasks.RerollDaily;

public class RerollDailyHandler : IRequestHandler<RerollDailyCommand, RerollDailyResult>
{
    private readonly ITaskRepository _taskRepository;
    private readonly IUserRepository _userRepository;

    public RerollDailyHandler(ITaskRepository taskRepository, IUserRepository userRepository)
    {
        _taskRepository = taskRepository;
        _userRepository = userRepository;
    }

    public async Task<RerollDailyResult> Handle(RerollDailyCommand request, CancellationToken cancellationToken)
    {
        var task = await _taskRepository.GetByIdAsync(request.TaskId)
            ?? throw new InvalidOperationException("Task not found.");

        if (task.UserId != request.UserId)
            throw new UnauthorizedAccessException("This task does not belong to the current user.");

        if (task.Type != TaskType.Daily)
            throw new InvalidOperationException("Only Daily tasks can be rerolled.");

        if (task.IsCompleted)
            throw new InvalidOperationException("Cannot reroll a completed task.");

        var user = await _userRepository.GetByIdAsync(request.UserId)
            ?? throw new InvalidOperationException("User not found.");

        if (user.Coins < 5)
            throw new InvalidOperationException("Not enough coins to reroll.");

        user.Coins -= 5;
        task.Title = $"Daily Task — {DateTime.UtcNow:yyyy-MM-dd HH:mm}";
        task.IsCompleted = false;

        await _userRepository.UpdateAsync(user);
        await _taskRepository.UpdateAsync(task);

        return new RerollDailyResult(task.Id, task.Title);
    }
}