using MediatR;
using UnDone.Application.Interfaces;
using UnDone.Application.Queries.Profile.GetProfile;

namespace UnDone.Application.Queries.Profile.GetProfile;

public class GetProfileHandler : IRequestHandler<GetProfileQuery, ProfileResponse>
{
    private readonly IUserRepository _userRepository;

    public GetProfileHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ProfileResponse> Handle(GetProfileQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId)
            ?? throw new InvalidOperationException("User not found.");

        var xpToNextLevel = 100 + (user.Level * 50);

        return new ProfileResponse(
            user.Id,
            user.Username,
            user.Email,
            user.Level,
            user.CurrentXp,
            xpToNextLevel,
            user.Coins,
            user.CurrentStreak,
            user.CreatedAt
        );
    }
}