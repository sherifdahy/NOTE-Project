import { Route } from '@angular/router';
import { LayoutComponent } from '../layouts/layout/layout.component';

export const remoteRoutes: Route[] = [
  {
    path : '',
    component : LayoutComponent,
    children : [

    ]
  }
];
