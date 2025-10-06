import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../../core/services/auth.service';
import { Role } from '../../../core/enums/role.enum';

@Component({
  selector: 'app-public-header',
  standalone: false,
  templateUrl: './public-header.component.html',
  styleUrls: ['./public-header.component.css']
})
export class PublicHeaderComponent implements OnInit {

  public isLoggedIn!: boolean;
  constructor(public authService: AuthService) {
  }

  ngOnInit() {
    this.authService.isLoggedIn.subscribe(response => {
      this.isLoggedIn = response;
    })

  }

  hasRoleAdmin(): boolean {
    return this.authService.currentUser?.roles.includes(Role[Role.Admin]) ? true : false;
  }

  handleLogoutClick() {
    this.authService.logout();
    this.authService.isLoggedIn.subscribe(response => {
      this.isLoggedIn = response;
    })
  }

}
