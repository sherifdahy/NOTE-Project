import { Route } from '@angular/router';

export const appRoutes: Route[] = [
  {
    path : 'auth',
    loadChildren : ()=> import('./features/auth/auth.module').then(m=>m.AuthModule)
  },
  {
    path: 'systemAdmin',
    loadChildren: () =>
      import('systemAdmin/Module').then((m) => m.RemoteEntryModule),
  },
  {
    path: 'admin',
    loadChildren: () =>
      import('admin/Module').then((m) => m.RemoteEntryModule),
  },
  {
    path: 'client',
    loadChildren: () =>
      import('client/Module').then((m) => m.RemoteEntryModule),
  },
  {
    path : '**',
    redirectTo : ''
  }
];
