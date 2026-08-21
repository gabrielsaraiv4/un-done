import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    redirectTo: 'home',
    pathMatch: 'full'
  },
  {
    path: 'home',
    loadComponent: () =>
      import('./features/home/home').then(m => m.Home)
  },
  {
    path: 'profile',
    loadComponent: () =>
      import('./features/profile/profile').then(m => m.Profile)
  },
  {
    path: 'dashboard',
    loadComponent: () =>
      import('./features/dashboard/dashboard').then(m => m.Dashboard)
  },
  {
    path: 'store',
    loadComponent: () =>
      import('./features/store/store').then(m => m.Store)
  },
  {
    path: 'settings',
    loadComponent: () =>
      import('./features/settings/settings').then(m => m.Settings)
  }
];