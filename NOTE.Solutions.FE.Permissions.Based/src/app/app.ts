import { Component, OnInit, signal } from '@angular/core';
import { AuthService } from './core/services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.html',
  standalone: false,
  styleUrl: './app.css'
})
export class App {

  constructor() {

  }


  protected readonly title = signal('NOTE.Solutions.FE.Permissions.Based');
}
