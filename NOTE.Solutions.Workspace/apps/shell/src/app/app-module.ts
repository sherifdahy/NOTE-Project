import { NgModule, provideBrowserGlobalErrorListeners } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { App } from './app';
import { appRoutes } from './app.routes';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { LoaderInterceptor, TokenInterceptor, ErrorInterceptor } from '@note-solutions-workspace/shared/interceptors';
import { NgxSpinnerModule } from 'ngx-spinner';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppToasterModule, AppTranslateModule} from '@note-solutions-workspace/shared/modules'

@NgModule({
  declarations: [
    App,
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(appRoutes),
    HttpClientModule,
    NgxSpinnerModule,
    BrowserAnimationsModule,
    AppTranslateModule.forRoot(),
    AppToasterModule.forRoot(),
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: LoaderInterceptor,
      multi: true,
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptor,
      multi: true
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ErrorInterceptor,
      multi: true
    },
    provideBrowserGlobalErrorListeners()
  ],
  bootstrap: [App],
})
export class AppModule { }
