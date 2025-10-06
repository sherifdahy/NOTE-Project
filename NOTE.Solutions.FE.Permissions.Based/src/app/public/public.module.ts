import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LandingLayoutComponent } from './layouts/landing-layout/landing-layout.component';
import { RouterModule, Routes } from '@angular/router';
import { LandingComponent } from './components/landing/landing.component';
import { PublicHeaderComponent } from './components/public-header/public-header.component';

const routes : Routes = [
  {
    path : '',
    component : LandingLayoutComponent,
    children : [
      {
        path : '',
        component : LandingComponent
      }
    ],
  }
];

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(routes),

],
  declarations: [LandingLayoutComponent,LandingComponent,PublicHeaderComponent]
})
export class PublicModule { }
