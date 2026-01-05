import { Route } from '@angular/router';
import {
  AccessDeniedComponent,
  NotFoundComponent,
  ServerErrorComponent,
} from '@app/shared/ui';

export const appRoutes: Route[] = [
  {
    path: 'client',
    loadChildren: () =>
      import('client/Module').then((m) => m!.RemoteEntryModule),
  },
  {
    path: 'systemAdmin',
    loadChildren: () =>
      import('systemAdmin/Module').then((m) => m!.RemoteEntryModule),
  },
  {
    path: '',
    loadChildren: () =>
      import('./features/landing/landing.module').then((d) => d.LandingModule),
  },
  {
    path: 'auth',
    loadChildren: () =>
      import('./features/auth/auth.module').then((m) => m.AuthModule),
  },
  {
    path: 'main',
    loadChildren: () =>
      import('./features/main/main.module').then((m) => m.MainModule),
  },
  {
    path: 'access-denaid',
    component: AccessDeniedComponent,
  },
  {
    path: 'server-error',
    component: ServerErrorComponent,
  },
  {
    path: '**',
    component: NotFoundComponent,
  },
];
