import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './pages/home/home.component';
import { ServicesComponent } from './pages/services/services.component';
import { AboutComponent } from './pages/about/about.component';
import { LandingRouterModule } from './landing.router.module';
import { LandingLayoutComponent } from './layouts/landing-layout/landing-layout.component';
import { HeaderComponent } from "./components/header/header.component";
import { TranslateService } from '@ngx-translate/core';
import { AppTranslateService } from '@app/shared/data-access';
import { AppTranslateModule } from '@app/shared/modules';

@NgModule({
  imports: [
    CommonModule,
    LandingRouterModule,
    AppTranslateModule.forChild('/landing.json'),
  ],
  declarations: [
    HomeComponent,
    ServicesComponent,
    AboutComponent,
    LandingLayoutComponent,
    HeaderComponent,
  ]
})
export class LandingModule {
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
