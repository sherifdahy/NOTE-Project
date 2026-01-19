import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AppTranslateService } from '@app/shared/data-access';

@Component({
  selector: 'app-header',
  standalone: false,
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  currentLang!: string;
  constructor(private router:Router,private appTranslateService: AppTranslateService) {
  }

  ngOnInit() {
    this.appTranslateService.language$.subscribe(lang => {
      this.currentLang = lang;
    })
  }

  changeLang(lang: string) {
    this.appTranslateService.changeLanguage(lang);
  }

  login(){
    this.router.navigate(['auth/login']);
  }
}
