import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '@app/shared/data-access';
import { JwtService } from 'libs/shared/data-access/src/lib/auth/jwt.service';

@Component({
  selector: 'app-dashboard-select',
  standalone: false,
  templateUrl: './dashboard-select.component.html',
  styleUrls: ['./dashboard-select.component.css']
})
export class DashboardSelectComponent implements OnInit {

  dashboards: string[] = [];
  constructor(private authService: AuthService, private jwtService: JwtService, private router: Router) { }

  ngOnInit() {
    const token = this.authService.currentUser?.token;
    if (token) {
      this.dashboards = this.jwtService.decodeToken(token).contexts as string[];
    }
  }


}
