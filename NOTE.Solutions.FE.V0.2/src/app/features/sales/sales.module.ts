import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SalesComponent } from './components/sales/sales.component';
import { RouterModule, Routes } from '@angular/router';

const routes : Routes =[
  {
    path : '',
    component : SalesComponent
  }
];

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  declarations: [SalesComponent],
})
export class SalesModule { }
