import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LayoutComponent } from './layouts/layout/layout.component';
import { HeaderComponent } from './components/header/header.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { RouterModule } from '@angular/router';
import { MainRoutingModule } from './main.router.module';


@NgModule({
  imports: [
    CommonModule,
    MainRoutingModule
  ],
  declarations: [
    LayoutComponent,
    HeaderComponent,
    SidebarComponent
  ]
})
export class MainModule { }
