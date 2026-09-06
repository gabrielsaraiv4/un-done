import { Injectable, signal } from '@angular/core';
import { ProfileService } from '../profile/profile';
import { ProfileResponse } from '../../../shared/models/profile.model';

@Injectable({
  providedIn: 'root'
})
export class UserStateService {
  readonly profile = signal<ProfileResponse | null>(null);

  constructor(private profileService: ProfileService) {}

  loadProfile(): void {
    this.profileService.getProfile().subscribe(profile => {
      this.profile.set(profile);
    });
  }

  refreshProfile(): void {
    this.loadProfile();
  }
}