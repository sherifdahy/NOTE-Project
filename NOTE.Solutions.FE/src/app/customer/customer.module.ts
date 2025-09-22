import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { HomeCustomerComponent } from './components/home-customer/home-customer.component';
import { MainLayoutComponent } from '../core/layouts/main-layout/main-layout.component';
import { HttpClientModule } from '@angular/common/http';
import { ProductsComponent } from './components/products/products/products.component';
import { CreateProductComponent } from './components/products/create-product/create-product.component';
import { EditProductComponent } from './components/products/edit-product/edit-product.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CreateProductUnitDialogComponent } from './components/products/create-product-unit-dialog/create-product-unit-dialog.component';
import { ReceiptsComponent } from './components/receipts/receipts/receipts.component';
import { CreateReceiptComponent } from './components/receipts/create-receipt/create-receipt.component';




const routes: Routes = [
  {
    path: '',
    component: MainLayoutComponent,
    children: [
      {
        path: '',
        redirectTo : 'home',
        pathMatch : 'full',
      },
      {
        path : 'home',
        component : HomeCustomerComponent,
      },
      {
        path : 'products',
        children : [
          {
            path : '',
            component : ProductsComponent,
          },
          {
          path : 'create',
            component : CreateProductComponent
          },
          {
            path : ':productId',
            component : EditProductComponent
          }
        ]
      },
      {
        path : 'receipts',
        children : [
          {
            path : '',
            component : ReceiptsComponent,
          },
          {
            path : 'create',
            component : CreateReceiptComponent,
          }
        ]
      }


    ]
  }
]

@NgModule({
  providers: [

  ],
  imports: [
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule.forChild(routes),
  ],
  declarations: [
    ProductsComponent,
    CreateProductComponent,
    CreateProductUnitDialogComponent,
    ReceiptsComponent,
    CreateReceiptComponent,
  ]
})
export class CustomerModule { }
