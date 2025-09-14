import { Injectable } from '@angular/core';
import { GenericApiHandlerService } from './generic-api-handler.service';
import { catchError, map, Observable, throwError } from 'rxjs';
import { CityResponse } from '../models/city/responses/city-response';

@Injectable({
  providedIn: 'root'
})
export class CityService {

  constructor(private apiCall: GenericApiHandlerService) { }

  getAll(): Observable<CityResponse[]> {
    return this.apiCall.get<CityResponse[]>('cities').pipe(
      map((response) => response as CityResponse[]),
      catchError((response) => {
        return throwError(response.error.errors)
      })
    )
  }
}
