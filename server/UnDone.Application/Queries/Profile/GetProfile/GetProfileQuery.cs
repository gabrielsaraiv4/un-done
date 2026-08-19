using MediatR;

namespace UnDone.Application.Queries.Profile.GetProfile;

public record GetProfileQuery(
    Guid UserId
) : IRequest<ProfileResponse>;

public record ProfileResponse(
    Guid Id,
    string Username,
    string Email,
    int Level,
    int CurrentXp,
    int XpToNextLevel,
    int Coins,
    int CurrentStreak,
    DateTime CreatedAt
);