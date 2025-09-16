import { Injectable } from '@angular/core';
import { GovernorateResponse } from '../models/governorate/responses/governorate-response';
import { catchError, map, Observable, throwError } from 'rxjs';
import { GenericApiHandlerService } from './generic-api-handler.service';
import { GovernorateRequest } from '../models/governorate/requests/governorate-request';
import { HttpErrorResponse } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class GovernorateService {

  constructor(private apiCall : GenericApiHandlerService) { }

  create(body: GovernorateRequest): Observable<void> {
    return this.apiCall.post<void>('governorates', body).pipe(
      catchError((response: HttpErrorResponse) => {
        return throwError(() => response.error.errors)
      })
    )
  }

  getAll(): Observable<GovernorateResponse[]> {
    return this.apiCall.get<GovernorateResponse[]>('governorates').pipe(
      map((response) => {
        return response as GovernorateResponse[];
      }),
      catchError((response) => {
        return throwError(() => response.error.errors);
      })
    )
  }

  delete(id: number): Observable<void> {
    return this.apiCall.delete(`governorates/${id}`).pipe(
      catchError((response: HttpErrorResponse) => {
        return throwError(() => response.error.errors)
      })
    );
  }
}
