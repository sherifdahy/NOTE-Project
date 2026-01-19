import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AppTranslateService, AuthService } from '@app/shared/data-access';

@Component({
  selector: 'app-header',
  standalone: false,
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  currentLang!: string;
  currentEmail! : string;
  constructor(private router : Router,private authService : AuthService,private appTranslateService: AppTranslateService) { }

  ngOnInit() {
    this.currentEmail = this.authService.currentUser?.email!;
    this.appTranslateService.language$.subscribe(lang => {
      this.currentLang = lang;
    })
  }

  changeLang(lang:string)
  {
    this.appTranslateService.changeLanguage(lang);
  }

  onLogout()
  {
    this.authService.logout().subscribe(response=>{
      this.router.navigateByUrl('/');
    });
  }
}
