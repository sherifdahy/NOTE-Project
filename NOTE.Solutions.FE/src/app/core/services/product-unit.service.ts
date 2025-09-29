import { Injectable } from '@angular/core';
import { ProductUnitReques } from '../models/product-unit/requests/product-unit-request';
import { catchError, map, Observable, throwError } from 'rxjs';
import { GenericApiHandlerService } from './generic-api-handler.service';
import { HttpErrorResponse } from '@angular/common/http';
import { ProductUnitResponse } from '../models/product-unit/responses/product-unit-response';

@Injectable({
  providedIn: 'root'
})
export class ProductUnitService {

constructor(private apiCall: GenericApiHandlerService) { }
  create(branchId : number,body: ProductUnitReques): Observable<void> {
    return this.apiCall.post<void>(`branches/${branchId}/productUnits`, body).pipe(
      catchError((response: HttpErrorResponse) => {
        return throwError(() => response.error.errors)
      })
    )
  }

  getAll(branchId:number): Observable<ProductUnitResponse[]> {
    return this.apiCall.get<ProductUnitResponse[]>(`branches/${branchId}/productUnits`).pipe(
      map((response) => {
        return response as ProductUnitResponse[];
      }),
      catchError((response) => {
        return throwError(() => response.error.errors);
      })
    )
  }

}
