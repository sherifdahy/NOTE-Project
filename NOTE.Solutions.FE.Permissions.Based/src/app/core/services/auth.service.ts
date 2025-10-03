import { Injectable } from '@angular/core';
import { ApiCallService } from './api-call.service';
import { AuthResponse } from '../models/authentication/responses/auth-response';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { User } from '../../authentication/models/user';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private localStorageKey = 'auth-obj';
  private user: BehaviorSubject<User | null>;

  constructor(private apiCall: ApiCallService) {
    this.user = new BehaviorSubject<User | null>(null);
    this.loadUserFromToken();
  }

  login(email: string, password: string): Observable<AuthResponse> {
    return this.apiCall.post<AuthResponse>('api/auth/get-token', {
      email,
      password
    }).pipe(
      tap(response => {
        localStorage.setItem(this.localStorageKey, JSON.stringify(response));
      })
    );
  }

  logout() {
    localStorage.removeItem(this.localStorageKey);
  }

  private loadUserFromToken() {
    const authObj = localStorage.getItem(this.localStorageKey) ? (JSON.parse(localStorage.getItem(this.localStorageKey)!) as AuthResponse) : null;

    if (!authObj) return;

    try {
      const payload = JSON.parse(atob(authObj.token.split('.')[1]));
      const user: User = {
        id: payload.sub,
        email: payload.email,
        roles: payload.roles,
        permissions: payload.permissions
      };
      this.user.next(user);
    } catch {
      this.logout();
    }
  }

  getToken(){
    const authObj = localStorage.getItem(this.localStorageKey) ? (JSON.parse(localStorage.getItem(this.localStorageKey)!) as AuthResponse) : null;
    return authObj?.token;
  }

  get currentUser(): User | null {
    return this.user.value;
  }

  get isLoggedIn(): boolean {
    return this.user.value !== null;
  }

}
