export interface ProfileResponse {
  id: string;
  username: string;
  email: string;
  level: number;
  currentXp: number;
  xpToNextLevel: number;
  coins: number;
  currentStreak: number;
  createdAt: string;
}