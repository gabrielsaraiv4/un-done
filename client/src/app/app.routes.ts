import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    redirectTo: 'home',
    pathMatch: 'full'
  },
  {
    path: 'home',
    title: 'Home',
    loadComponent: () =>
      import('./features/home/home').then(m => m.Home)
  },
  {
    path: 'profile',
    title: 'Profile',
    loadComponent: () =>
      import('./features/profile/profile').then(m => m.Profile)
  },
  {
    path: 'dashboard',
    title: 'Dashboard',
    loadComponent: () =>
      import('./features/dashboard/dashboard').then(m => m.Dashboard)
  },
  {
    path: 'store',
    title: 'Store',
    loadComponent: () =>
      import('./features/store/store').then(m => m.Store)
  },
  {
    path: 'settings',
    title: 'Settings',
    loadComponent: () =>
      import('./features/settings/settings').then(m => m.Settings)
  }
];