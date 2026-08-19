using MediatR;
using UnDone.Application.Interfaces;
using UnDone.Application.Queries.Dashboard.GetDashboard;

namespace UnDone.Application.Queries.Dashboard.GetDashboard;

public class GetDashboardHandler : IRequestHandler<GetDashboardQuery, DashboardResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly ITaskRepository _taskRepository;

    public GetDashboardHandler(IUserRepository userRepository, ITaskRepository taskRepository)
    {
        _userRepository = userRepository;
        _taskRepository = taskRepository;
    }

    public async Task<DashboardResponse> Handle(GetDashboardQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdWithBadgesAsync(request.UserId) ?? throw new InvalidOperationException("User not found.");

        var tasks = await _taskRepository.GetAllByUserIdAsync(request.UserId);
        var completedTasks = tasks.Where(t => t.IsCompleted).ToList();

        var totalXpEarned = completedTasks.Sum(t => t.XpReward);
        var xpToNextLevel = 100 + (user.Level * 50);

        var recentBadges = user.UserBadges
            .OrderByDescending(ub => ub.EarnedAt)
            .Take(5)
            .Select(ub => new RecentBadgeResponse(
                ub.Badge.Id,
                ub.Badge.Name,
                ub.Badge.Description,
                ub.Badge.IconUrl,
                ub.EarnedAt
            ));

        return new DashboardResponse(
            user.Level,
            user.CurrentXp,
            xpToNextLevel,
            user.CurrentStreak,
            completedTasks.Count,
            totalXpEarned,
            recentBadges
        );
    }
}