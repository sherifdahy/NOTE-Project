import { Injectable } from '@angular/core';

@Injectable({ 'providedIn': 'root' })
export class AuthService {

  login() {
    alert('User logged in');
    return true;
  }
}
