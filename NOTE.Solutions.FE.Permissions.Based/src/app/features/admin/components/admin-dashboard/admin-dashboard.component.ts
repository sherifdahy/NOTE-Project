import { Component, OnInit } from '@angular/core';
import { Permission } from '../../../../authentication/enums/permissions.enum';

@Component({
  selector: 'app-admin-dashboard',
  standalone : false,
  templateUrl: './admin-dashboard.component.html',
  styleUrls: ['./admin-dashboard.component.css']
})
export class AdminDashboardComponent implements OnInit {
  public permission = Permission;
  constructor() { }

  ngOnInit() {
  }

}
