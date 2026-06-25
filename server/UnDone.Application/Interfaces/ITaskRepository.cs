using UnDone.Domain.Entities;

namespace UnDone.Application.Interfaces;

public interface ITaskRepository
{
    Task<TaskItem?> GetByIdAsync(Guid id);
    Task<IEnumerable<TaskItem>> GetAllByUserIdAsync(Guid userId);
    Task<IEnumerable<TaskItem>> GetDailyByUserIdAsync(Guid userId);
    Task AddAsync(TaskItem task);
    Task UpdateAsync(TaskItem task);
    Task DeleteAsync(TaskItem task);
}