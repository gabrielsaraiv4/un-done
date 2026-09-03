using MediatR;
using UnDone.Application.Interfaces;

namespace UnDone.Application.Queries.Tasks.GetTasks;

public class GetTasksHandler : IRequestHandler<GetTasksQuery, IEnumerable<TaskResponse>>
{
    private readonly ITaskRepository _taskRepository;

    public GetTasksHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<IEnumerable<TaskResponse>> Handle(GetTasksQuery request, CancellationToken cancellationToken)
    {
        var tasks = await _taskRepository.GetAllByUserIdAsync(request.UserId);

        return tasks.Select(t => new TaskResponse(
            t.Id,
            t.Title,
            t.Description,
            t.Type,
            t.Difficulty,
            t.IsCompleted,
            t.XpReward,
            t.CoinReward,
            t.CreatedAt
        ));
    }
}