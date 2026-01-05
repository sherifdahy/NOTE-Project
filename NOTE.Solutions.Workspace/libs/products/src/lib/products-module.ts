import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductListComponent } from './ui/product-list/product-list.component';
import { ProductFormComponent } from './ui/product-form/product-form.component';
import { ProductDetailsComponent } from './ui/product-details/product-details.component';

@NgModule({
  imports: [CommonModule],
  declarations: [
    ProductListComponent,
    ProductFormComponent,
    ProductDetailsComponent
  ]
})
export class ProductsModule { }
