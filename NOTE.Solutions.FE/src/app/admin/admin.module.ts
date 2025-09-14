import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { HomeAdminComponent } from './components/home-admin/home-admin.component';
import { MainLayoutComponent } from '../core/layouts/main-layout/main-layout.component';

const routes : Routes = [
  {
    path : '',
    component : MainLayoutComponent,
    children : [
      {
        path : '',
        component : HomeAdminComponent,
      }
    ]
  }
]

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
  ],
  declarations: [HomeAdminComponent]
})
export class AdminModule { }
