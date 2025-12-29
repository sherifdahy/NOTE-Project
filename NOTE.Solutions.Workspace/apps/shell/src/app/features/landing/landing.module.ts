import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { LandingLayoutComponent } from '../../layouts/landing-layout/landing-layout.component';
import { HomeComponent } from './pages/home/home.component';

const routes : Routes = [
  {
    path : '',
    component : LandingLayoutComponent,
    children : [
      {
        path : '',
        component : HomeComponent,
      },
      {
        path : 'home',
        redirectTo : ''
      }
    ]
  }
]

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  declarations: [
    LandingLayoutComponent,
    HomeComponent,
  ]
})
export class LandingModule { }
