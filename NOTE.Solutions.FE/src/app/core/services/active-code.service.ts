import { Injectable } from '@angular/core';
import { GenericApiHandlerService } from './generic-api-handler.service';
import { catchError, map, Observable, retry, throwError } from 'rxjs';
import { ActiveCodeResponse } from '../models/active-code/response/active-code-response';
import { AuthService } from './auth.service';
import { HttpErrorResponse } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ActiveCodeService {

  constructor(
    private authService : AuthService,
    private apiCall: GenericApiHandlerService
  ) {

  }

  getAll () : Observable<ActiveCodeResponse[]>{
    return this.apiCall.get<ActiveCodeResponse[]>('activecodes').pipe(
      map((response) => {
        return response as ActiveCodeResponse[];
      }),
      catchError((response)=>{
        return throwError(()=>response.error.errors);
      })
    )
  }

  delete(id : number): Observable<void>{
    return this.apiCall.delete(`activecodes/${id}`).pipe(
      catchError((response : HttpErrorResponse)=>{
        return throwError(()=> response.error.errors)
      })
    );
  }
}
