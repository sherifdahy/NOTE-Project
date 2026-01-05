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
    path: 'system-admin',
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
