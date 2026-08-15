using UnDone.Domain.Enums;

namespace UnDone.Application.Commands.Tasks.CreateTask;

public record CreateTaskRequest(
    string Title,
    string? Description,
    TaskType Type,
    TaskDifficulty Difficulty
);