import { Injectable } from '@angular/core';
import { GenericApiHandlerService } from './generic-api-handler.service';
import { catchError, map, Observable, throwError } from 'rxjs';
import { PosRequest } from '../models/pos/requests/pos-request';
import { HttpErrorResponse } from '@angular/common/http';
import { PosResponse } from '../models/pos/responses/pos-response';

@Injectable({
  providedIn: 'root'
})
export class PosService {

constructor(private apiCall : GenericApiHandlerService) { }
  create( branchId : number,body: PosRequest): Observable<void> {
    return this.apiCall.post<void>(`branches/${branchId}/poss`, body).pipe(
      catchError((response: HttpErrorResponse) => {
        return throwError(() => response.error.errors)
      })
    )
  }

  getAll(branchId : number): Observable<PosResponse[]> {
    return this.apiCall.get<PosResponse[]>(`branches/${branchId}/poss`).pipe(
      map((response) => {
        return response as PosResponse[];
      }),
      catchError((response) => {
        return throwError(() => response.error.errors);
      })
    )
  }


}
