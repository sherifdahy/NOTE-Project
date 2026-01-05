import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { remoteRoutes } from './entry.routes';
import { LayoutComponent } from '../layouts/layout/layout.component';
import { HeaderComponent } from '../shared/ui/ui/header/header.component';
import { SidebarComponent } from '../shared/ui/ui/sidebar/sidebar.component';

@NgModule({
  declarations: [
    LayoutComponent,
    HeaderComponent,
    SidebarComponent
  ],
  imports: [CommonModule, RouterModule.forChild(remoteRoutes)],
  providers: [],
})
export class RemoteEntryModule { }
