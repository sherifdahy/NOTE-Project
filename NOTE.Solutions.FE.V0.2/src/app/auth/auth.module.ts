import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthLayoutComponent } from './layouts/auth-layout/auth-layout.component';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

const routes : Routes = [
  {
    path : '',
    component : AuthLayoutComponent,
    children : [
      {
        path : 'login',
        component : LoginComponent,
      },
      {
        path : 'register',
        component : RegisterComponent,
      }
    ]
  }
];

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    ReactiveFormsModule,
    FormsModule
  ],
  declarations: [AuthLayoutComponent,LoginComponent,RegisterComponent]
})
export class AuthModule { }
