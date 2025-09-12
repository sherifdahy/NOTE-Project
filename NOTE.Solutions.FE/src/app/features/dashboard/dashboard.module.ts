import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './components/home/home.component';
import { RouterModule, Routes } from '@angular/router';
import { MainLayoutComponent } from '../../core/layouts/main-layout/main-layout.component';
import { HeaderComponent } from "../../shared/components/header/header.component";
import { SidebarComponent } from "../../shared/components/sidebar/sidebar.component";
import { FooterComponent } from "../../shared/components/footer/footer.component";

const routes : Routes = [
  {
    path : '',
    component : MainLayoutComponent,
    children : [
      {
        path : '',
        component : HomeComponent
      },
      {
        path : 'home',
        component : HomeComponent,
      }
    ]
  }
]

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    HeaderComponent,
    SidebarComponent,
    FooterComponent
],
  declarations: [HomeComponent,MainLayoutComponent]
})
export class DashboardModule { }
