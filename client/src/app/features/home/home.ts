import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TaskService } from '../../core/services/task/task';
import { UserStateService } from '../../core/services/user-state/user-state';
import { TaskResponse } from '../../shared/models/task.model';
import { signal } from '@angular/core';

@Component({
  selector: 'app-home',
  imports: [CommonModule],
  templateUrl: './home.html',
  styleUrl: './home.scss'
})
export class Home implements OnInit {
  tasks = signal<TaskResponse[]>([]);

  constructor(
    private taskService: TaskService,
    protected userState: UserStateService
  ) {}

  ngOnInit(): void {
    this.loadTasks();
  }

  loadTasks(): void {
    this.taskService.getTasks().subscribe(tasks => {
      this.tasks.set(tasks);
    });
  }

  get dailyTasks() {
    return this.tasks().filter(t => t.type === 1 && !t.isCompleted);
  }

  get oneShotTasks() {
    return this.tasks().filter(t => t.type === 0 && !t.isCompleted);
  }

  get completedTasks() {
    return this.tasks().filter(t => t.isCompleted);
  }

  completeTask(taskId: string): void {
    this.taskService.completeTask(taskId).subscribe(() => {
      this.loadTasks();
      this.userState.refreshProfile();
    });
  }
}