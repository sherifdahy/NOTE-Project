import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { RolesPageComponent } from './pages/roles-page/roles-page.component';
import { RoleCardComponent } from "./components/role-card/role-card.component";
import { FormsModule, ReactiveFormsModule } from '@angular/forms'
import { RoleFormPageComponent } from './pages/role-form-page/role-form-page.component';

const routes: Routes = [
  {
    path: '',
    component: RolesPageComponent
  },
  {
    path: ':id',
    component: RoleFormPageComponent
  },
  {
    path : 'create',
    component : RoleFormPageComponent
  }
]

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    FormsModule,
    ReactiveFormsModule
  ],
  declarations: [
    RolesPageComponent,
    RoleFormPageComponent,
    RoleCardComponent
  ]
})
export class RolesModule { }
