import { Injectable } from '@angular/core';
import { GovernorateResponse } from '../models/governorate/responses/governorate-response';
import { catchError, map, Observable, throwError } from 'rxjs';
import { GenericApiHandlerService } from './generic-api-handler.service';

@Injectable({
  providedIn: 'root'
})
export class GovernorateService {

  constructor(private apiCall : GenericApiHandlerService) { }

  getAll(): Observable<GovernorateResponse[]> {
    return this.apiCall.get<GovernorateResponse[]>('Governates').pipe(
      map(response => response as GovernorateResponse[]),
      catchError(response => {
        return throwError(response.error.errors);
      })
    )
  }
}
