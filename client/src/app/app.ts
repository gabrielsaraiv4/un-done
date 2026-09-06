import { RouterOutlet, Router, NavigationEnd } from '@angular/router';
import { filter } from 'rxjs';
import { Sidebar } from './shared/components/sidebar/sidebar';
import { Header } from './shared/components/header/header';
import { PageTitleService } from './core/services/page-title/page-title';
import { UserStateService } from './core/services/user-state/user-state';
import { Component, OnInit, signal } from '@angular/core';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Sidebar, Header],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App implements OnInit {
  showLayout = signal(true);

  private authRoutes = ['/login', '/register'];

  constructor(
    protected pageTitle: PageTitleService,
    protected userState: UserStateService,
    private router: Router
  ) {
    this.router.events
      .pipe(filter(event => event instanceof NavigationEnd))
      .subscribe((event: any) => {
        this.showLayout.set(!this.authRoutes.includes(event.urlAfterRedirects));
      });
  }

  ngOnInit(): void {
    this.userState.loadProfile();
  }
}