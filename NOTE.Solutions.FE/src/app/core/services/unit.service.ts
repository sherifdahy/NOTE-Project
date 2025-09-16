import { Injectable } from '@angular/core';
import { GenericApiHandlerService } from './generic-api-handler.service';
import { catchError, map, Observable, throwError } from 'rxjs';
import { UnitRequest } from '../models/unit/requests/unit-request';
import { HttpErrorResponse } from '@angular/common/http';
import { UnitResponse } from '../models/unit/responses/unit-response';

@Injectable({
  providedIn: 'root'
})
export class UnitService {

  constructor(private apiCall : GenericApiHandlerService) { }
  create(body: UnitRequest): Observable<void> {
    return this.apiCall.post<void>('units', body).pipe(
      catchError((response: HttpErrorResponse) => {
        return throwError(() => response.error.errors)
      })
    )
  }

  getAll(): Observable<UnitResponse[]> {
    return this.apiCall.get<UnitResponse[]>('units').pipe(
      map((response) => {
        return response as UnitResponse[];
      }),
      catchError((response) => {
        return throwError(() => response.error.errors);
      })
    )
  }

  delete(id: number): Observable<void> {
    return this.apiCall.delete(`units/${id}`).pipe(
      catchError((response: HttpErrorResponse) => {
        return throwError(() => response.error.errors)
      })
    );
  }
}
