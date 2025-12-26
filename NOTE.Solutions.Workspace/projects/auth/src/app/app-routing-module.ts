import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LayoutComponent } from './layouts/layout/layout.component';
import { LoginPageComponent } from './features/login/pages/login-page/login-page.component';
import { ResetPasswordPageComponent } from './features/reset-password/pages/reset-password-page/reset-password-page.component';
import { ForgetPasswordPageComponent } from './features/forget-password/pages/forget-password-page/forget-password-page.component';

const routes: Routes = [
  {
    path: '',
    component: LayoutComponent,
    children:
      [
        {
          path: 'login',
          component : LoginPageComponent
        },
        {
          path : 'forget-password',
          component : ForgetPasswordPageComponent
        },
        {
          path : 'reset-password',
          component : ResetPasswordPageComponent
        }
      ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
