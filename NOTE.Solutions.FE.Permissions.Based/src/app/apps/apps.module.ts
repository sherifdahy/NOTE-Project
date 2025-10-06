import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppsLayoutComponent } from './layouts/apps-layout/apps-layout.component';
import { RouterModule, Routes } from '@angular/router';
import { AppsHeaderComponent } from "./components/apps-header/apps-header.component";

const routes : Routes = [
  {
    path : '',
    component : AppsLayoutComponent,
    children : [
      {
        path : 'sales',
        loadChildren : ()=> import('../features/sales/sales.module').then(x=>x.SalesModule),
      }
    ]
  }
];

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
],
  declarations: [AppsLayoutComponent,AppsHeaderComponent]
})
export class AppsModule { }
