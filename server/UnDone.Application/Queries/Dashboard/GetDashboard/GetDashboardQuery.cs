using MediatR;

namespace UnDone.Application.Queries.Dashboard.GetDashboard;

public record GetDashboardQuery(
    Guid UserId
) : IRequest<DashboardResponse>;

public record DashboardResponse(
    int Level,
    int CurrentXp,
    int XpToNextLevel,
    int CurrentStreak,
    int TotalTasksCompleted,
    int TotalXpEarned,
    IEnumerable<RecentBadgeResponse> RecentBadges
);

public record RecentBadgeResponse(
    Guid BadgeId,
    string Name,
    string Description,
    string IconUrl,
    DateTime EarnedAt
);