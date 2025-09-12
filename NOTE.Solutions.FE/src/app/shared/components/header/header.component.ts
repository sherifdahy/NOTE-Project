import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../../core/services/auth.service';
import { Route, Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  constructor(private router : Router,private authService : AuthService) { }

  ngOnInit() {
  }


  handleLogoutClick(){
    this.authService.logout();
    this.router.navigateByUrl('/auth/login')
  }
}
