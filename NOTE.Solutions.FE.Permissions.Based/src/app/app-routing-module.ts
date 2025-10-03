import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './features/authentication/components/login/login.component';
import { RegisterComponent } from './features/authentication/components/register/register.component';
import { NotFoundComponent } from './shared/components/not-found/not-found.component';
import { NoAccessComponent } from './shared/components/no-access/no-access.component';
import { AuthLayoutComponent } from './shared/layouts/auth-layout/auth-layout.component';
import { LandingPageComponent } from './shared/components/landing-page/landing-page.component';
import { hasRoleGuard } from './core/guards/has-role-guard';
import { Role } from './authentication/enums/role.enum';
import { isLoggedInGuard } from './core/guards/is-logged-in-guard';

const routes: Routes = [
  {
    path : 'login',
    component : AuthLayoutComponent,
    children: [
      {
        path : '',
        component : LoginComponent,
      }
    ]
  },
  {
    path : 'register',
    component : AuthLayoutComponent,
    children: [
      {
        path : '',
        component : RegisterComponent,
      }
    ]
  },
  {
    path : '',
    component : LandingPageComponent,
  },
  {
    path : 'admin',
    canActivate : [isLoggedInGuard,hasRoleGuard],
    data : {'roles' : [Role[Role.Admin]]},
    loadChildren : ()=> import('./features/admin/admin.module').then(x=>x.AdminModule)
  },
  {
    path : 'apps/sales',
    loadChildren : ()=> import('./features/sales/sales.module').then(x=>x.SalesModule)
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
