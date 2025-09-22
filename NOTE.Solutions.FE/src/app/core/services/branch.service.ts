import { Injectable } from '@angular/core';
import { GenericApiHandlerService } from './generic-api-handler.service';
import { catchError, map, Observable, throwError } from 'rxjs';
import { BranchRequest } from '../models/branch/requests/branch-request';
import { HttpErrorResponse } from '@angular/common/http';
import { BranchResponse } from '../models/branch/responses/branch-response';

@Injectable({
  providedIn: 'root'
})
export class BranchService {

  constructor(private apiCall: GenericApiHandlerService) { }

  create(body: BranchRequest): Observable<void> {
    return this.apiCall.post<void>('branches', body).pipe(
      catchError((response: HttpErrorResponse) => {
        return throwError(() => response.error.errors)
      })
    )
  }

  getAll(): Observable<BranchResponse[]> {
    return this.apiCall.get<BranchResponse[]>('branches').pipe(
      map((response) => {
        return response as BranchResponse[];
      }),
      catchError((response) => {
        return throwError(() => response.error.errors);
      })
    )
  }

  delete(id: number): Observable<void> {
    return this.apiCall.delete(`branches/${id}`).pipe(
      catchError((response: HttpErrorResponse) => {
        return throwError(() => response.error.errors)
      })
    );
  }
}
