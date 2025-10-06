import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../../core/services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-system-admin-dashboard',
  standalone : false,
  templateUrl: './system-admin-dashboard.component.html',
  styleUrls: ['./system-admin-dashboard.component.css']
})
export class SystemAdminDashboardComponent implements OnInit {

  constructor(private router : Router,private authService : AuthService) { }

  ngOnInit() {
  }
}
