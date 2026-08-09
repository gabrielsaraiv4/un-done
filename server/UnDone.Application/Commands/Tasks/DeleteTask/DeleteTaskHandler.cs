using MediatR;
using UnDone.Application.Interfaces;

namespace UnDone.Application.Commands.Tasks.DeleteTask;

public class DeleteTaskHandler : IRequestHandler<DeleteTaskCommand, Unit>
{
    private readonly ITaskRepository _taskRepository;

    public DeleteTaskHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<Unit> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        var task = await _taskRepository.GetByIdAsync(request.TaskId)
            ?? throw new InvalidOperationException("Task not found.");

        if (task.UserId != request.UserId)
            throw new UnauthorizedAccessException("This task does not belong to the current user.");
        
        await _taskRepository.DeleteAsync(task);

        return Unit.Value;
    }
}