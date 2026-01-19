import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { remoteRoutes } from './entry.routes';
import { LayoutComponent } from '../layouts/layout/layout.component';
import { HeaderComponent } from '../shared/ui/header/header.component';
import { SidebarComponent } from '../shared/ui/sidebar/sidebar.component';
import { DashboardPageComponent } from '../features/dashboard/pages/dashboard-page/dashboard-page.component';

@NgModule({
  declarations: [
    LayoutComponent,
    HeaderComponent,
    SidebarComponent,
    DashboardPageComponent
  ],
  imports: [CommonModule, RouterModule.forChild(remoteRoutes)],
  providers: [],
})
export class RemoteEntryModule { }
