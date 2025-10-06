import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { RolesComponent } from './components/roles/roles.component';
import { NewRoleComponent } from './components/new-role/new-role.component';
import { FormsModule } from '@angular/forms';

const routes : Routes = [
  {
    path : 'roles',
    component : RolesComponent,
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
  ],
  declarations: [RolesComponent,NewRoleComponent]
})
export class RoleModule { }
