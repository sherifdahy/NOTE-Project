import { Component, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { LoginFormComponent } from './components/login-form/login-form.component';
import { RegisterFormComponent } from './components/register-form/register-form.component';
import { AuthLayoutComponent } from '../../core/layouts/auth-layout/auth-layout.component';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

const routes : Routes = [
  {
    path : '',
    component : AuthLayoutComponent,
    children:[
      {path : 'login' , component : LoginFormComponent},
      {path : 'register', component : RegisterFormComponent}
    ]
  }
]

@NgModule({

  imports: [
    CommonModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule.forChild(routes)
  ],
  declarations:[
    LoginFormComponent,
    RegisterFormComponent,
    AuthLayoutComponent
  ]
})
export class AuthModule { }
