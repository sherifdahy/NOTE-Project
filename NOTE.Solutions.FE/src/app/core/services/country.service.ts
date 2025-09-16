import { Injectable } from '@angular/core';
import { GenericApiHandlerService } from './generic-api-handler.service';
import { catchError, map, Observable, throwError } from 'rxjs';
import { CountryResponse } from '../models/country/responses/country-response';
import { HttpErrorResponse } from '@angular/common/http';
import { CountryRequest } from '../models/country/requests/country-request';

@Injectable({
  providedIn: 'root'
})
export class CountryService {

  constructor(private apiCall: GenericApiHandlerService) { }

  create(body: CountryRequest): Observable<void> {
    return this.apiCall.post<void>('countries', body).pipe(
      catchError((response: HttpErrorResponse) => {
        return throwError(() => response.error.errors)
      })
    )
  }

  getAll(): Observable<CountryResponse[]> {
    return this.apiCall.get<CountryResponse[]>('countries').pipe(
      map((response) => {
        return response as CountryResponse[];
      }),
      catchError((response) => {
        return throwError(() => response.error.errors);
      })
    )
  }

  delete(id: number): Observable<void> {
    return this.apiCall.delete(`countries/${id}`).pipe(
      catchError((response: HttpErrorResponse) => {
        return throwError(() => response.error.errors)
      })
    );
  }
}
