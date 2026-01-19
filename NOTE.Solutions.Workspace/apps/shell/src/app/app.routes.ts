import { Route } from '@angular/router';
import {
  AccessDeniedComponent,
  NotFoundComponent,
  ServerErrorComponent,
} from '@app/shared/ui';

import { authGuard, branchGuard, hasContextGuard } from '@app/shared/guards'

export const appRoutes: Route[] = [
  {
    path: '',
    loadChildren: () => import('./features/landing/landing.module').then(x => x.LandingModule)
  },
  {
    path: 'client',
    canActivate: [authGuard, hasContextGuard, branchGuard],
    data: { 'required-context': 'client' },
    loadChildren: () =>
      import('client/Module').then((m) => m!.RemoteEntryModule),
  },
  {
    path: 'system-admin',
    canActivate: [authGuard, hasContextGuard],
    data: { 'required-context': 'System Admin' },
    loadChildren: () => import('systemAdmin/Module').then((m) => m!.RemoteEntryModule),
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
