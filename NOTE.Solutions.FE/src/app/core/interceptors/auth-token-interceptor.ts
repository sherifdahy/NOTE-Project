import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, switchMap, take, throwError } from 'rxjs';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';

// لازم تبقا injectable
// عشان هستخدم فيها حاجة من الـ DI


@Injectable()
export class AuthTokenInterceptor implements HttpInterceptor {
  constructor(
    private authService: AuthService,
    private router: Router,
  ) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    // Interceptor
    // عبارة عن service
    // بستخدمها عشان اعدل الـ request
    // سواء بقا اضيف او اشف حاجة منه
    // كذلك الـ response


    // request is immutable
    // يعني الـ request مينفعش اعدل عليه
    // الحل اني اعمل clone لل request
    // والنسخة الجديدة دي اعدل عليه برحتي


    // next => عبارة عن handler
    // بستخدمها عشان اسلم الـ request
    // interceptor التاني
    // او الـ back end لو مفيش interceptor

    // interceptor
    // لازم يبقا في الـ app module


    let accessToken = this.authService.getAccessToken;
    if (!accessToken) {
      return next.handle(req);
    }

    let modifiedRequest = req.clone({ headers: req.headers.append('Authorization', `Bearer ${this.authService.getAccessToken}`) })
    return next.handle(modifiedRequest).pipe(
      catchError((error: HttpErrorResponse) => {
        if (error.status === 401) {
          this.authService.logout();
          this.router.navigate(['auth/login']);
        }
        return throwError(() => error);
      })
    );
  }
};
