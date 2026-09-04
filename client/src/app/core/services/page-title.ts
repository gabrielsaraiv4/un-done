import { Injectable, signal } from '@angular/core';
import { Router, NavigationEnd, ActivatedRouteSnapshot } from '@angular/router';
import { filter } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PageTitleService {
  readonly title = signal('');

  constructor(private router: Router) {
    this.router.events
      .pipe(filter(event => event instanceof NavigationEnd))
      .subscribe(() => {
        let route: ActivatedRouteSnapshot = this.router.routerState.snapshot.root;
        while (route.firstChild) {
          route = route.firstChild;
        }
        this.title.set(route.title ?? '');
      });
  }
}