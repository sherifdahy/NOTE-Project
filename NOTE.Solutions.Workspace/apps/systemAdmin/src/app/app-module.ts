import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { App } from './app';

@NgModule({
  declarations: [App],
  imports: [
    // BrowserModule,
    RouterModule.forChild(
      [
        {
          path: '',
          loadChildren: () =>
            import('./remote-entry/entry-module').then(
              (m) => m.RemoteEntryModule,
            ),
        },
      ],
      // { initialNavigation: 'enabledBlocking' },
    ),
  ],
  providers: [],
  bootstrap: [App],
})
export class AppModule {}
