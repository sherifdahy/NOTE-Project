import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UsersFormPageComponent } from './pages/users-form-page/users-form-page.component';
import { UsersPageComponent } from './pages/users-page/users-page.component';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [
    UsersFormPageComponent,
    UsersPageComponent
  ]
})
export class UsersModule { }
