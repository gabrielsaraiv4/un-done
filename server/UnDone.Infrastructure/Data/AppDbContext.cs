using Microsoft.EntityFrameworkCore;
using UnDone.Domain.Entities;

namespace UnDone.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<TaskItem> Tasks { get; set; }
    public DbSet<Badge> Badges { get; set; }
    public DbSet<UserBadge> UserBadges { get; set; }
    public DbSet<ShopItem> ShopItems { get; set; }
    public DbSet<UserItem> UserItems { get; set; }
    public DbSet<ActiveEffect> ActiveEffects { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // User
        modelBuilder.Entity<User> (entity =>
        {
            entity.HasKey(u => u.Id);
            entity.HasIndex(u => u.Email).IsUnique();
            entity.HasIndex(u => u.Username).IsUnique();
        });

        // TaskItem
        modelBuilder.Entity<TaskItem>(entity =>
        {
            entity.HasKey(t => t.Id);
            entity.HasOne(t => t.User)
                .WithMany(u => u.Tasks)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // UserBadge
        modelBuilder.Entity<UserBadge>(entity =>
        {
            entity.HasKey(ub => ub.Id);
            entity.HasOne(ub => ub.User)
                .WithMany(u => u.UserBadges)
                .HasForeignKey(ub => ub.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(ub => ub.Badge)
                .WithMany(b => b.UserBadges)
                .HasForeignKey(ub => ub.BadgeId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // UserItem
        modelBuilder.Entity<UserItem>(entity =>
        {
            entity.HasKey(ui => ui.Id);
            entity.HasOne(ui => ui.User)
                .WithMany(u => u.UserItems)
                .HasForeignKey(ui => ui.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(ui => ui.ShopItem)
                .WithMany(si => si.UserItems)
                .HasForeignKey(ui => ui.ShopItemId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // ActiveEffect
        modelBuilder.Entity<ActiveEffect>(entity =>
        {
            entity.HasKey(ae => ae.Id);
            entity.HasOne(ae => ae.User)
                .WithMany(u => u.ActiveEffects)
                .HasForeignKey(ae => ae.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}