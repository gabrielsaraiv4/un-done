namespace UnDone.Domain.Entities;

/// <summary>
/// 1. Represents a application user.
/// 2. Holds both authentication data and gamification state.
/// </summary>

public class User
{
    public Guid Id { get; set; }

    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;

    // Gamification
    public int Level { get; set; } = 1;
    public int CurrentXp { get; set; } = 0;
    public int Coins { get; set; } = 0;

    // Streak counting/tracking
    public int CurrentStreak {get; set; } = 0;
    public DateOnly? LastActivityDate {get; set;}
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Navigation properties
    public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
    public ICollection<UserBadge> UserBadges { get; set; } = new List<UserBadge>();
    public ICollection<UserItem> UserItems { get; set; } = new List<UserItem>();
    public ICollection<ActiveEffect> ActiveEffects { get; set; } = new List<ActiveEffect>();
}