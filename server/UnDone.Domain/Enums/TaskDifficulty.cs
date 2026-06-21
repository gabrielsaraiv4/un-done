namespace UnDone.Domain.Enums;

/// <summary>
/// 1. Defines the difficulty of a task, which determines its XP and coin rewards.
/// 1.1. Daily tasks uses a fixed reward regardless of this value being set for consistency,
/// but Easy, Medium and Hard applies to One-shot tasks.

public enum TaskDifficulty
{
   Easy = 0,
   Medium = 1,
   Hard = 3,
   Daily = 3 
}