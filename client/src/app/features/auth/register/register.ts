import { Component, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterLink, Router } from '@angular/router';
import { AuthService } from '../../../core/services/auth';

@Component({
  selector: 'app-register',
  imports: [FormsModule, RouterLink],
  templateUrl: './register.html',
  styleUrl: './register.scss'
})
export class Register {
  username = '';
  email = '';
  password = '';
  isLoading = signal(false);
  errorMessage = signal('');
  successMessage = signal('');

  constructor(private authService: AuthService, private router: Router) {}

  onSubmit(): void {
    this.isLoading.set(true);
    this.errorMessage.set('');
    this.successMessage.set('');

    this.authService.register({
      username: this.username,
      email: this.email,
      password: this.password
    }).subscribe({
      next: () => {
        this.successMessage.set('Account created! Redirecting to login...');
        setTimeout(() => this.router.navigate(['/login']), 1500);
      },
      error: (err) => {
        this.errorMessage.set(err.error?.error ?? 'Registration failed. Please try again.');
        this.isLoading.set(false);
      }
    });
  }
}