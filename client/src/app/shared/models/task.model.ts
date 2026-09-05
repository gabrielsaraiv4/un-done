export enum TaskType {
  OneShot = 0,
  Daily = 1
}

export enum TaskDifficulty {
  Easy = 0,
  Medium = 1,
  Hard = 2,
  Daily = 3
}

export interface TaskResponse {
  id: string;
  title: string;
  description?: string;
  type: TaskType;
  difficulty: TaskDifficulty;
  isCompleted: boolean;
  xpReward: number;
  coinReward: number;
  createdAt: string;
}

export interface CreateTaskRequest {
  title: string;
  description?: string;
  type: TaskType;
  difficulty: TaskDifficulty;
}

export interface CompleteTaskResult {
  taskId: string;
  xpEarned: number;
  coinsEarned: number;
  newLevel: number;
  newXp: number;
  newCoins: number;
}