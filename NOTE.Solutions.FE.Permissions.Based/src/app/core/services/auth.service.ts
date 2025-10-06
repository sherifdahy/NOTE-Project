import { Injectable } from '@angular/core';
import { ApiCallService } from './api-call.service';
import { AuthResponse } from '../models/authentication/responses/auth-response';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { AuthenticatedUserResponse } from '../models/authentication/responses/authenticated-user-response';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private localStorageKey = 'auth-obj';
  private userSubject: BehaviorSubject<AuthenticatedUserResponse | null>;
  private isLoggedInSubject : BehaviorSubject<boolean>;
  constructor(private apiCall: ApiCallService) {
    this.userSubject = new BehaviorSubject<AuthenticatedUserResponse | null>(null);
    this.isLoggedInSubject = new BehaviorSubject<boolean>(false);
    this.loadUserFromToken();
  }

  login(email: string, password: string): Observable<AuthResponse> {
    return this.apiCall.post<AuthResponse>('api/auth/get-token', {
      email,
      password
    }).pipe(
      tap(response => {
        localStorage.setItem(this.localStorageKey, JSON.stringify(response));
        this.loadUserFromToken();
      })
    );
  }

  logout() {
    localStorage.removeItem(this.localStorageKey);
    this.isLoggedInSubject.next(false);
  }

  private loadUserFromToken() {
    const authObj = localStorage.getItem(this.localStorageKey) ? (JSON.parse(localStorage.getItem(this.localStorageKey)!) as AuthResponse) : null;

    if (!authObj) return;

    try {
      const payload = JSON.parse(atob(authObj.token.split('.')[1]));
      const user: AuthenticatedUserResponse = {
        id: payload.sub,
        email: payload.email,
        roles: payload.roles,
        permissions: payload.permissions
      };
      this.userSubject.next(user);
      this.isLoggedInSubject.next(true);
    } catch {
      this.logout();
    }
  }

  getToken(){
    const authObj = localStorage.getItem(this.localStorageKey) ? (JSON.parse(localStorage.getItem(this.localStorageKey)!) as AuthResponse) : null;
    return authObj?.token;
  }

  get currentUser(): AuthenticatedUserResponse | null {
    return this.userSubject.value;
  }

  get isLoggedIn() : Observable<boolean>{
    return this.isLoggedInSubject.asObservable();
  }
}
