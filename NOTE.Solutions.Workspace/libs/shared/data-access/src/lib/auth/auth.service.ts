import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { JwtService } from './jwt.service';
import { AuthStorageService } from './auth-storage.service';
import { ApiClientService } from '../api/api-client.service';
import { AuthResponse, LoginRequest, ForgetPasswordRequest } from '@app/shared/models';
import { environment } from 'environment';

@Injectable({
  providedIn: 'root',
})
export class AuthService {

  private currentUserSubject = new BehaviorSubject<AuthResponse | null>(null);

  constructor(private apiCall: ApiClientService, private authStorageService: AuthStorageService, private jwtService: JwtService) {
    this.checkOnInit();
  }

  checkOnInit() {
    const temp = this.authStorageService.get();
    if (temp)
      this.currentUserSubject.next(temp);
    else
      this.currentUserSubject.next(null);
  }

  login(request: LoginRequest): Observable<AuthResponse> {
    return this.apiCall.post<AuthResponse>(`${environment.apiUrl}/api/auth/get-token`, request).pipe(
      tap(response => {
        this.authStorageService.save(response);
        this.currentUserSubject.next(response);
      })
    );
  }

  logout(): Observable<any> {
    return this.apiCall.post(`${environment.apiUrl}/api/auth/revoke`, {
      token: this.currentUserSubject.value?.token,
      refreshToken: this.currentUserSubject.value?.refreshToken
    }).pipe((response) => {
      this.currentUserSubject.next(null);
      return response;
    }
    )
  }

  forgetPassword(request: ForgetPasswordRequest): Observable<void> {
    return this.apiCall.post<void>(`${environment.apiUrl}/api/auth/forget-password`, request);
  }

  refreshToken(): Observable<AuthResponse> {
    return this.apiCall
      .post<AuthResponse>(`${environment.apiUrl}/api/auth/refresh`, {
        token: this.currentUserSubject.value?.token,
        refreshToken: this.currentUserSubject.value?.refreshToken,
      })
      .pipe(
        tap((response) => {
          this.authStorageService.save(response);
          this.currentUserSubject.next(response);
        })
      );
  }

  // resetPassword(request: NewPasswordRequest): Observable<void> {
  //   return this.apiCall.post<void>(API_ENDPOINTS_CONSTS.AUTH.RESET_PASSWORD, request);
  // }

  get currentUser$(): Observable<AuthResponse | null> {
    return this.currentUserSubject.asObservable();
  }

  get currentUser(): AuthResponse | null {
    return this.currentUserSubject.value;
  }

  get isLoggedIn(): boolean {
    return this.currentUserSubject.value == null ? false : true;
  }

}






