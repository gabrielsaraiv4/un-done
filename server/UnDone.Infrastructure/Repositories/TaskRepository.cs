using Microsoft.EntityFrameworkCore;
using UnDone.Application.Interfaces;
using UnDone.Domain.Entities;
using UnDone.Infrastructure.Data;

namespace UnDone.Infrastructure.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly AppDbContext _context;

    public TaskRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<TaskItem?> GetByIdAsync(Guid id)
    {
        return await _context.Tasks.FindAsync(id);
    }

    public async Task<IEnumerable<TaskItem>> GetAllByUserIdAsync(Guid userId)
    {
        return await _context.Tasks
        .Where(t => t.UserId == userId)
        .ToListAsync();
    }

    public async Task<IEnumerable<TaskItem>> GetDailyByUserIdAsync(Guid userId)
    {
        return await _context.Tasks
        .Where(t => t.UserId == userId && t.Type == Domain.Enums.TaskType.Daily)
        .ToListAsync();
    }

    public async Task AddAsync(TaskItem task)
    {
        await _context.Tasks.AddAsync(task);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TaskItem task)
    {
        _context.Tasks.Update(task);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(TaskItem task)
    {
        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();
    }
}
