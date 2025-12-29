import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthRoutingModule } from './auth.routing.module';
import { AuthLayoutComponent } from '../../layouts/auth-layout/auth-layout.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LoginFormComponent } from './components/login-form/login-form.component';
import { ForgetPasswordComponent } from './components/forget-password/forget-password.component';
import { DisplayErrorComponent } from '@note-solutions-workspace/shared/ui'

@NgModule({
  imports: [
    CommonModule,
    AuthRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    DisplayErrorComponent
  ],
  declarations: [
    AuthLayoutComponent,
    LoginFormComponent,
    ForgetPasswordComponent
  ]
})
export class AuthModule { }
