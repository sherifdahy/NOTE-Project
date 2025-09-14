import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable, NgZone } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, Observable, tap, throwError } from 'rxjs';
import { AuthService } from '../services/auth.service';

@Injectable()
export class AuthErrorInterceptor implements HttpInterceptor {
  constructor(private ngZone: NgZone, private router: Router) {

  }
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(req).pipe(

      catchError(err => {
        if (err.status == 401 || err.status == 403) {
            this.ngZone.run(()=>{
              alert(err.status);
              this.router.navigateByUrl('auth/login');
            });
        }
        return throwError(() => err);
      })
    )
  }
};
