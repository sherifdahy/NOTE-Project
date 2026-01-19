import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthRoutingModule } from './auth.routing.module';
import { AuthLayoutComponent } from './layouts/auth-layout/auth-layout.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LoginFormComponent } from './components/login-form/login-form.component';
import { DisplayErrorComponent } from '@app/shared/ui'
import { ResetPasswordComponent } from './components/reset-password/reset-password.component';
import { ForgetPasswordComponent } from './components/forget-password/forget-password.component';
import { MatTooltipModule } from '@angular/material/tooltip';
import { AppTranslateModule } from '@app/shared/modules';
import { TranslateService } from '@ngx-translate/core';
import { AppTranslateService } from '@app/shared/data-access';
import { HeaderComponent } from "./components/header/header.component";
import { BranchSelectComponent } from './components/branch-select/branch-select.component';
import { DashboardSelectComponent } from './components/dashboard-select/dashboard-select.component';


@NgModule({
  imports: [
    CommonModule,
    AuthRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    DisplayErrorComponent,
    MatTooltipModule,
    AppTranslateModule.forChild('/auth.json'),

],
  declarations: [
    AuthLayoutComponent,
    LoginFormComponent,
    ResetPasswordComponent,
    ForgetPasswordComponent,
    HeaderComponent,
    BranchSelectComponent,
    DashboardSelectComponent
  ]
})

export class AuthModule {
  constructor(
    private translateService: TranslateService,
    private appTranslateService: AppTranslateService
  ) {
    this.appTranslateService.language$.subscribe((lang) => {
      this.translateService.getTranslation(lang).subscribe((file) => {
        this.translateService.setTranslation(lang, file, true);
      });
    });
  }
}
