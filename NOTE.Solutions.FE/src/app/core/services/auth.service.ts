import { Injectable } from '@angular/core';
import { GenericApiHandlerService } from './generic-api-handler.service';
import { LoginRequest } from '../models/auth/requests/login-request';
import { BehaviorSubject, catchError, map, Observable, tap, throwError } from 'rxjs';
import { AuthResponse } from '../models/auth/responses/auth-response';
import { RegisterCompanyRequest } from '../models/auth/requests/register-company-request';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private roleSubject: BehaviorSubject<string | null>;
  constructor(
    private apiCall: GenericApiHandlerService
  ) {
    this.roleSubject = new BehaviorSubject<string | null>(null);

    const token = this.getAccessToken;
    if (token) {
      const payload = this.decodeToken(token);
      console.log(payload);
      this.roleSubject.next(payload.role);
    }
  }

  login(loginRequest: LoginRequest): Observable<AuthResponse> {
    return this.apiCall.post<AuthResponse>(`auth/login`, loginRequest).pipe(
      map(response => response as AuthResponse),
      tap(response => {
        this.setAccessToken = response.token as string;
      }
      ),
      catchError(response => {
        return throwError(() => response.error.errors);
      })
    );
  }

  registerCompany(registerCompanyRequest: RegisterCompanyRequest): Observable<any> {
    return this.apiCall.post<any>('auth/register-company', registerCompanyRequest).pipe(
      catchError(response => {
        return throwError(() => response.error.errors);
      })
    );
  }

  logout(): void {
    localStorage.removeItem('token');
    this.roleSubject.next(null);
  }
  private decodeToken(token: string): any {
    try {
      return JSON.parse(atob(token.split('.')[1]));
    } catch {
      return {};
    }
  }

  get getAccessToken(): string {
    return localStorage.getItem('token') as string;
  }

  private set setAccessToken(token: string) {
    localStorage.setItem('token', token);
    const payload = this.decodeToken(token);
    this.roleSubject.next(payload.role);
  }

  get getRole(): Observable<string | null> {
    return this.roleSubject.asObservable();
  }
}
