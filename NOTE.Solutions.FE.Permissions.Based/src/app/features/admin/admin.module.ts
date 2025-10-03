import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminDashboardComponent } from './components/admin-dashboard/admin-dashboard.component';
import { RouterModule, Routes } from '@angular/router';
import { DashboardLayoutComponent } from '../../shared/layouts/dashboard-layout/dashboard-layout.component';
import { HasPermissionDirective } from "../../shared/directives/has-permission.directive";

const routes :Routes  = [
  {
    path : '',
    component : DashboardLayoutComponent,
    children : [
      {
        path : '',
        component : AdminDashboardComponent,
      }
    ]
  }
]

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    HasPermissionDirective
],
  declarations: [AdminDashboardComponent,DashboardLayoutComponent]
})
export class AdminModule { }
