import { Component, OnInit } from '@angular/core';
import { AppTranslateService } from '@app/shared/data-access';

@Component({
  selector: 'app-header',
  standalone: false,
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  currentLang!: string;
  constructor(private appTranslateService: AppTranslateService) {
  }

  ngOnInit() {
    this.appTranslateService.language$.subscribe(lang => {
      this.currentLang = lang;
    })
  }

  changeLang(lang: string) {
    this.appTranslateService.changeLanguage(lang);
  }

}
