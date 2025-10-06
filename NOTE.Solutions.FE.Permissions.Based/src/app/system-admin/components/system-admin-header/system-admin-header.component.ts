import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../../core/services/auth.service';

@Component({
  selector: 'app-system-admin-header',
  standalone : false,
  templateUrl: './system-admin-header.component.html',
  styleUrls: ['./system-admin-header.component.css']
})
export class SystemAdminHeaderComponent implements OnInit {

  public isLoggedIn! : boolean;
  constructor(private authService : AuthService) { }

  ngOnInit() {
    this.authService.isLoggedIn.subscribe(response=>{
      this.isLoggedIn = response;
    });
  }

  handleLogoutClick(){
    this.authService.logout();
  }
}
