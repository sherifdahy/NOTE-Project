import { Injectable } from '@angular/core';
import { catchError, map, Observable, throwError } from 'rxjs';
import { ProductRequest } from '../models/product/requests/product-request';
import { HttpErrorResponse } from '@angular/common/http';
import { GenericApiHandlerService } from './generic-api-handler.service';
import { ProductResponse } from '../models/product/responses/product-response';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private apiCall: GenericApiHandlerService) { }
  create(branchId : number,body: ProductRequest): Observable<void> {
    return this.apiCall.post<void>(`branches/${branchId}/products`, body).pipe(
      catchError((response: HttpErrorResponse) => {
        return throwError(() => response.error.errors)
      })
    )
  }

  getAll(branchId:number): Observable<ProductResponse[]> {
    return this.apiCall.get<ProductResponse[]>(`branches/${branchId}/products`).pipe(
      map((response) => {
        return response as ProductResponse[];
      }),
      catchError((response) => {
        return throwError(() => response.error.errors);
      })
    )
  }

  delete(id: number): Observable<void> {
    return this.apiCall.delete(`products/${id}`).pipe(
      catchError((response: HttpErrorResponse) => {
        return throwError(() => response.error.errors)
      })
    );
  }
}
