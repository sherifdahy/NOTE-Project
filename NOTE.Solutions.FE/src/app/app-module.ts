import { NgModule, provideBrowserGlobalErrorListeners } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing-module';
import { App } from './app';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { MainLayoutComponent } from './core/layouts/main-layout/main-layout.component';
import { AuthLayoutComponent } from './core/layouts/auth-layout/auth-layout.component';
import { HeaderComponent } from './shared/components/header/header.component';
import {AuthTokenInterceptor } from './core/interceptors/auth-token-interceptor';
import { AdminSidebarComponent } from './admin/components/admin-sidebar/admin-sidebar.component';
import { CustomerSidebarComponent } from './customer/components/customer-sidebar/customer-sidebar.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgxSpinnerModule } from 'ngx-spinner';
import { loaderInterceptor } from './core/interceptors/loader-interceptor';
import { MatDialogModule } from '@angular/material/dialog';

@NgModule({
  declarations: [
    App,
    MainLayoutComponent,
    AuthLayoutComponent,
    HeaderComponent,
    AdminSidebarComponent,
    CustomerSidebarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    NgxSpinnerModule,
    MatDialogModule
  ],
  providers: [
    {
      provide : HTTP_INTERCEPTORS,
      useClass : loaderInterceptor,
      multi:true,
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthTokenInterceptor,
      multi: true
    },
    provideBrowserGlobalErrorListeners()
  ],
  bootstrap: [App]
})
export class AppModule { }
