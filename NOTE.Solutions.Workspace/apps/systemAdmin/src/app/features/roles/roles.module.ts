import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { RolesPageComponent } from './pages/roles-page/roles-page.component';
import { RoleDetailPageComponent } from './pages/role-detail-page/role-detail-page.component';

const routes: Routes = [
  {
    path: '',
    component: RolesPageComponent
  },
  {
    path: ':id',
    component: RoleDetailPageComponent
  }
]

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
  ],
  declarations: [
    RolesPageComponent,
    RoleDetailPageComponent
  ]
})
export class RolesModule { }
