import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-main-layout',
  standalone: false,
  templateUrl: './main-layout.component.html',
  styleUrls: ['./main-layout.component.css'],
})
export class MainLayoutComponent implements OnInit {
  roles!: string[] | null;
  constructor(private authService: AuthService) { }

  ngOnInit() {
    this.roles = this.authService.getRoles;
  }

}
