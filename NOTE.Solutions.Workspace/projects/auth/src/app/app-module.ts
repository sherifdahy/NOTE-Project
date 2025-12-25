import { NgModule, provideBrowserGlobalErrorListeners } from '@angular/core';

import { AppRoutingModule } from './app-routing-module';
import { CommonModule } from '@angular/common';

@NgModule({
  declarations: [
  ],
  imports: [
    CommonModule,
    AppRoutingModule
  ],
  providers: [
    provideBrowserGlobalErrorListeners()
  ],
})
export class AppModule { }
