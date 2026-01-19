import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginFormComponent } from './components/login-form/login-form.component';
import { AuthLayoutComponent } from './layouts/auth-layout/auth-layout.component';
import { ForgetPasswordComponent } from './components/forget-password/forget-password.component';
import { BranchSelectComponent } from './components/branch-select/branch-select.component';
import { authGuard, guestGuard } from '@app/shared/guards';
import { DashboardSelectComponent } from './components/dashboard-select/dashboard-select.component';

const routes: Routes = [
  {
    path: '',
    component: AuthLayoutComponent,
    children: [
      {
        path: 'select-dashboard',
        component: DashboardSelectComponent
      },
      {
        path: 'login',
        canActivate: [guestGuard],
        component: LoginFormComponent
      },
      {
        path: 'forget-password',
        canActivate: [guestGuard],
        component: ForgetPasswordComponent
      },
      {
        path: 'branch-select',
        canActivate: [authGuard],
        component: BranchSelectComponent
      }
    ]
  }
]

@NgModule({
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class AuthRoutingModule { }
