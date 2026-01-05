import { Injectable } from '@angular/core';
import { STORAGE_KEY_CONSTS } from '@app/shared/constants';
import { TranslateService } from '@ngx-translate/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AppTranslateService {

  private languageSubject = new BehaviorSubject<string>(
    this.getInitialLanguage()
  );

  language$ = this.languageSubject.asObservable();

  constructor(private translateService: TranslateService) {
    this.initialize();
  }

  changeLanguage(lang: string): void {
    if (lang === this.languageSubject.value) return;

    this.setDirection(lang);
    this.translateService.use(lang);
    this.languageSubject.next(lang);

    localStorage.setItem(
      STORAGE_KEY_CONSTS.APP_LANGUAGE,
      lang
    );
  }

  get currentLanguage(): string {
    return this.languageSubject.value;
  }

  private initialize(): void {
    const lang = this.languageSubject.value;

    this.translateService.setDefaultLang('en');

    this.translateService.use(lang);
    this.setDirection(lang);
  }

  private getInitialLanguage(): string {
    return (
      localStorage.getItem(STORAGE_KEY_CONSTS.APP_LANGUAGE) || 'en'
    );
  }

  private setDirection(lang: string): void {
    document.documentElement.dir = lang == 'en' ? 'ltr' : 'rtl';
  }
}
