import { Injectable } from '@angular/core';
import { GenericApiHandlerService } from './generic-api-handler.service';
import { catchError, map, Observable, throwError } from 'rxjs';
import { CountryResponse } from '../models/country/responses/country-response';

@Injectable({
  providedIn: 'root'
})
export class CountryService {

  constructor(private apiCall: GenericApiHandlerService) { }

  getAll() : Observable<CountryResponse[]>{
    return this.apiCall.get<CountryResponse[]>('countries').pipe(
      map(response=> response as CountryResponse[]),
      catchError(response=>{
        return throwError(response.error.errors);
      })
    )
  }
}
