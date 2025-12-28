import { NxWelcome } from './nx-welcome';
import { Route } from '@angular/router';

export const appRoutes: Route[] = [
  {
    path: 'systemAdmin',
    loadChildren: () =>
      import('systemAdmin/Module').then((m) => m.RemoteEntryModule),
  },
  {
    path: '',
    component: NxWelcome,
  },
];
