namespace UnDone.Domain.Entities;

/// <summary>
/// Join entity recording which badges a user has earned and when.
/// </summary>

public class UserBadge
{
    public Guid Id { get; set; }
    
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public Guid BadgeId { get; set; }
    public Badge Badge { get; set; } = null!;

    public DateTime EarnedAt { get; set; } = DateTime.UtcNow;
}