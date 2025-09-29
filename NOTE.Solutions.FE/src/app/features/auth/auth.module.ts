import { Component, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { AuthLayoutComponent } from '../../core/layouts/auth-layout/auth-layout.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RegisterCompanyComponent } from './components/register-company/register-company.component';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { LoginComponent } from './components/login/login.component';

const routes: Routes = [
  {
    path: '',
    component: AuthLayoutComponent,
    children: [
      { path : '', redirectTo : 'login',pathMatch :'full'},
      { path: 'login', component: LoginComponent },
      { path: 'register-company', component: RegisterCompanyComponent },
    ]
  }
]

@NgModule({

  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forChild(routes),
    MatDialogModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatTableModule,
    MatIconModule,

  ],
  declarations: [
    RegisterCompanyComponent,
    LoginComponent,
  ],
  bootstrap: [LoginComponent],
})
export class AuthModule { }
