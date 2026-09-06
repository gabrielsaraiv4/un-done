import { Component, CUSTOM_ELEMENTS_SCHEMA, OnInit } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { UserStateService } from '../../../core/services/user-state/user-state';

@Component({
  selector: 'app-sidebar',
  imports: [RouterLink, RouterLinkActive],
  templateUrl: './sidebar.html',
  styleUrl: './sidebar.scss',
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class Sidebar implements OnInit {
  constructor(protected userState: UserStateService) {}

  ngOnInit(): void {
    this.userState.loadProfile();
  }
}