import { Injectable } from '@angular/core';
import { GenericApiHandlerService } from './generic-api-handler.service';
import { catchError, map, Observable, throwError } from 'rxjs';
import { CityResponse } from '../models/city/responses/city-response';
import { CityRequest } from '../models/city/requests/city-request';
import { HttpErrorResponse } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CityService {

  constructor(private apiCall: GenericApiHandlerService) { }

  create(body: CityRequest): Observable<void> {
    return this.apiCall.post<void>('cities', body).pipe(
      catchError((response: HttpErrorResponse) => {
        return throwError(() => response.error.errors)
      })
    )
  }

  getAll(): Observable<CityResponse[]> {
    return this.apiCall.get<CityResponse[]>('cities').pipe(
      map((response) => {
        return response as CityResponse[];
      }),
      catchError((response) => {
        return throwError(() => response.error.errors);
      })
    )
  }

  delete(id: number): Observable<void> {
    return this.apiCall.delete(`cities/${id}`).pipe(
      catchError((response: HttpErrorResponse) => {
        return throwError(() => response.error.errors)
      })
    );
  }
}
