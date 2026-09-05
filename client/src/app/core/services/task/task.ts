import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TaskResponse, CreateTaskRequest, CompleteTaskResult } from '../../../shared/models/task.model';

@Injectable({
  providedIn: 'root'
})
export class TaskService {
  private readonly apiUrl = 'http://localhost:5033/api/tasks';

  constructor(private http: HttpClient) {}

  getTasks(): Observable<TaskResponse[]> {
    return this.http.get<TaskResponse[]>(this.apiUrl);
  }

  createTask(request: CreateTaskRequest): Observable<TaskResponse> {
    return this.http.post<TaskResponse>(this.apiUrl, request);
  }

  completeTask(taskId: string): Observable<CompleteTaskResult> {
    return this.http.post<CompleteTaskResult>(`${this.apiUrl}/${taskId}/complete`, {});
  }

  deleteTask(taskId: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${taskId}`);
  }

  rerollDaily(taskId: string): Observable<{ taskId: string; newTitle: string }> {
    return this.http.post<{ taskId: string; newTitle: string }>(`${this.apiUrl}/${taskId}/reroll`, {});
  }
}