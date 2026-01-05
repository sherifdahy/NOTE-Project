import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginFormComponent } from './components/login-form/login-form.component';
import { AuthLayoutComponent } from './layouts/auth-layout/auth-layout.component';
import { ForgetPasswordComponent } from './components/forget-password/forget-password.component';

const routes: Routes = [
  {
    path: '',
    component: AuthLayoutComponent,
    children : [
      {
        path : 'login',
        component : LoginFormComponent
      },
      {
        path : 'forget-password',
        component : ForgetPasswordComponent
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
