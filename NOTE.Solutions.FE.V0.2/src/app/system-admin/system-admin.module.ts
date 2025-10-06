import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { SystemAdminLayoutComponent } from './layouts/system-admin-layout/system-admin-layout.component';
import { AppRoutingModule } from "../app-routing-module";
import { SystemAdminDashboardComponent } from './components/system-admin-dashboard/system-admin-dashboard.component';
import { SystemAdminHeaderComponent } from './components/system-admin-header/system-admin-header.component';
import { SystemAdminSidebarComponent } from './components/system-admin-sidebar/system-admin-sidebar.component';

const routes: Routes = [
  {
    path: '',
    component: SystemAdminLayoutComponent,
    children: [
      {
        path: '',
        redirectTo : 'dashboard',
        pathMatch : 'full',
      },
      {
        path: 'dashboard',
        component: SystemAdminDashboardComponent,
      },
      {
        path : 'address-management',
        loadChildren : ()=> import('../features/address/address.module').then(x=>x.AddressModule)
      },
      {
        path : 'role-management',
        loadChildren : ()=> import('../features/role/role.module').then(x=>x.RoleModule)
      },

    ]
  }
];

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
  ],
  declarations: [
    SystemAdminLayoutComponent,
    SystemAdminHeaderComponent,
    SystemAdminSidebarComponent,
    SystemAdminDashboardComponent,
  ]
})
export class SystemAdminModule { }
