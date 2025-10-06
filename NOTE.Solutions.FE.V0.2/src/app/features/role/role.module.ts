import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { RolesComponent } from './components/roles/roles.component';
import { NewRoleComponent } from './components/new-role/new-role.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RoleDetailComponent } from './components/role-detail/role-detail.component';

const routes : Routes = [
  {
    path : 'roles',
    children :[
      {
        path : '',
        component : RolesComponent,
      },
      {
        path : ':id',
        component : RoleDetailComponent
      }
    ]
  },
  {
    path : 'new',
    component : NewRoleComponent,
  }
];

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forChild(routes),
    ReactiveFormsModule
],
  declarations: [RolesComponent,NewRoleComponent,RoleDetailComponent]
})
export class RoleModule { }
