import { Route } from '@angular/router';
import { LayoutComponent } from '../layouts/layout/layout.component';
import { DashboardPageComponent } from '../features/dashboard/pages/dashboard-page/dashboard-page.component';

export const remoteRoutes: Route[] = [
  {
    path: '',
    component: LayoutComponent,
    children: [
      {
        path: '',
        redirectTo: 'dashboard',
        pathMatch: 'full'
      },
      {
        path: 'dashboard',
        component: DashboardPageComponent
      },
      {
        path: 'roles',
        loadChildren: () => import('../features/roles/roles.module').then(x => x.RolesModule)
      }
    ]
  }
];
