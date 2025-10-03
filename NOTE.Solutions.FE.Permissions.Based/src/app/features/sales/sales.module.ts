import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SalesComponent } from './components/sales/sales.component';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [SalesComponent],
  bootstrap : [SalesComponent]
})
export class SalesModule { }
