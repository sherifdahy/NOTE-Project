import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './pages/home/home.component';
import { ServicesComponent } from './pages/services/services.component';
import { AboutComponent } from './pages/about/about.component';
import { LandingRouterModule } from './landing.router.module';
import { LandingLayoutComponent } from '../../layouts/landing-layout/landing-layout.component';

@NgModule({
  imports: [
    CommonModule,
    LandingRouterModule
  ],
  declarations: [
    HomeComponent,
    ServicesComponent,
    AboutComponent,
    LandingLayoutComponent
  ]
})
export class LandingModule { }
