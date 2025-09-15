import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { HomeAdminComponent } from './components/home-admin/home-admin.component';
import { MainLayoutComponent } from '../core/layouts/main-layout/main-layout.component';
import { ActiveCodesComponent } from './components/active-codes/active-codes/active-codes.component';
import { ActiveCodeDialog } from './components/active-codes/active-code-dialog/active-code-dialog';

const routes : Routes = [
  {
    path : '',
    component : MainLayoutComponent,
    children : [
      {
        path : '',
        component : HomeAdminComponent,
      },
      {
        path : 'home',
        component : HomeAdminComponent,
      },
      {
        path : "activecodes",
        component : ActiveCodesComponent
      },
    ]
  }
]

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
  ],
  declarations: [
    ActiveCodesComponent,
    ActiveCodeDialog,
  ]
})
export class AdminModule { }
