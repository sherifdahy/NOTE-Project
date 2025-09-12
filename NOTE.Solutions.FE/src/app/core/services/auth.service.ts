import { Injectable } from '@angular/core';
import { GenericApiHandlerService } from './generic-api-handler.service';
import { LoginRequest } from '../models/auth/requests/login-request';
import { BehaviorSubject, catchError, map, Observable, tap, throwError } from 'rxjs';
import { TokenResponse } from '../models/auth/responses/token-response';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private isLoggedSubject: BehaviorSubject<boolean>;
  constructor(private apiCall: GenericApiHandlerService) {
    this.isLoggedSubject = new BehaviorSubject<boolean>(this.hasValidToken());
  }

  private hasValidToken() : boolean{
    let token = localStorage.getItem('token');
    if(!token)
      return false;

    let expireAt = localStorage.getItem('expireAt');
    if(!expireAt)
      return false;

    let currentDateTime = new Date();

    if(currentDateTime >= new Date(expireAt))
    {
      localStorage.removeItem('token');
      localStorage.removeItem('expireAt');
      return false;
    }

    return true;
  }

  login(loginRequest: LoginRequest): Observable<TokenResponse> {
    return this.apiCall.post<TokenResponse>(`auth/login`, loginRequest).pipe(
      map(response => response as TokenResponse),
      tap(response =>{
        localStorage.setItem('token',response.token),
        localStorage.setItem('expireAt',(new Date().getTime() + response.expireIn).toString());
        this.isLoggedSubject.next(true)
      }
      ),
      catchError(response => {
        this.isLoggedSubject.next(false)
        return throwError(() => response.error.errors);
      })
    );
  }

  logout():void {
    localStorage.removeItem('token');
    this.isLoggedSubject.next(false);
  }

  get isLogged() : Observable<boolean>
  {
    return this.isLoggedSubject.asObservable();
  }
}
