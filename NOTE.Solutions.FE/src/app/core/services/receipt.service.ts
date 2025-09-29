import { Injectable } from '@angular/core';
import { GenericApiHandlerService } from './generic-api-handler.service';
import { catchError, map, Observable, throwError } from 'rxjs';
import { HttpErrorResponse } from '@angular/common/http';
import { ReceiptRequest } from '../models/receipt/requests/receipt-request';
import { ReceiptResponse } from '../models/receipt/responses/receipt-response';

@Injectable({
  providedIn: 'root'
})
export class ReceiptService {

constructor(private apiCall : GenericApiHandlerService) { }

create(branchId : number,body: ReceiptRequest): Observable<void> {
    return this.apiCall.post<void>(`branches/${branchId}/receipts`, body).pipe(
      catchError((response: HttpErrorResponse) => {
        return throwError(() => response.error.errors)
      })
    )
  }

  getAll(branchId : number): Observable<ReceiptResponse[]> {
    return this.apiCall.get<ReceiptResponse[]>(`branches/${branchId}/receipts`).pipe(
      map((response) => {
        return response as ReceiptResponse[];
      }),
      catchError((response) => {
        return throwError(() => response.error.errors);
      })
    )
  }

  getNextNumber(branchId : number): Observable<number> {
    return this.apiCall.get<number>(`branches/${branchId}/receipts/next-number`).pipe(
      map((response) => {
        return response as number;
      }),
      catchError((response) => {
        return throwError(() => response.error.errors);
      })
    )
  }
}
