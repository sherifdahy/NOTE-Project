import { ModuleWithProviders, NgModule } from '@angular/core';
import { ToastrModule } from 'ngx-toastr'
@NgModule()
export class AppToasterModule {
  static forRoot(): ModuleWithProviders<ToastrModule> {
    return ToastrModule.forRoot({
      positionClass: 'toast-bottom-right',
      timeOut: 3000,
      preventDuplicates: true,
    })
  }
}

