import { NgModule, provideBrowserGlobalErrorListeners } from '@angular/core';

import { AppRoutingModule } from './app-routing-module';
import { CommonModule } from '@angular/common';
import { LayoutComponent } from './layouts/layout/layout.component';
import { LoginPageComponent } from './features/login/pages/login-page/login-page.component';
import { LoginFormComponent } from './features/login/components/login-form/login-form.component';
import { ForgetPasswordFormComponent } from './features/forget-password/components/forget-password-form/forget-password-form.component';
import { ResetPasswordFormComponent } from './features/reset-password/components/reset-password-form/reset-password-form.component';
import { ResetPasswordPageComponent } from './features/reset-password/pages/reset-password-page/reset-password-page.component';
import { ForgetPasswordPageComponent } from './features/forget-password/pages/forget-password-page/forget-password-page.component';
import { ErrorComponent, SharedModule } from 'core-lib';



@NgModule({
  declarations: [
    // layouts
    LayoutComponent,

    // pages
    LoginPageComponent,
    ResetPasswordPageComponent,
    ForgetPasswordPageComponent,

    //components
    LoginFormComponent,
    ForgetPasswordFormComponent,
    ResetPasswordFormComponent
  ],
  imports: [
    CommonModule,
    AppRoutingModule,
    SharedModule,
    ErrorComponent
  ],
  providers: [
    provideBrowserGlobalErrorListeners()
  ],
})
export class AppModule { }
