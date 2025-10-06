import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotFoundComponent } from './shared/components/not-found/not-found.component';
import { NoAccessComponent } from './shared/components/no-access/no-access.component';
import { isLoggedInGuard } from './core/guards/is-logged-in-guard';
import { hasRoleGuard } from './core/guards/has-role-guard';
import { Role } from './core/enums/role.enum';

const routes: Routes = [
  {
    path : '',
    loadChildren : ()=> import('./public/public.module').then(x=>x.PublicModule),
  },
  {
    path : 'auth',
    loadChildren : ()=> import('./auth/auth.module').then(x=>x.AuthModule)
  },
  {
    path : 'apps',
    // canActivate : [isLoggedInGuard,hasRoleGuard],
    data : {'roles': [Role[Role.Employee],Role[Role.Owner]]},
    loadChildren: ()=> import('./apps/apps.module').then(x=>x.AppsModule),
  },
  {
    path : 'system-admin',
    canActivate : [isLoggedInGuard,hasRoleGuard],
    data : {'roles': [Role[Role.Admin]]},
    loadChildren: ()=> import('./system-admin/system-admin.module').then(x=>x.SystemAdminModule),
  },
  {
    path : 'no-access',
    component : NoAccessComponent
  },
  {
    path : '**',
    component : NotFoundComponent,
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
