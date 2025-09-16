import { Injectable } from '@angular/core';
import { GenericApiHandlerService } from './generic-api-handler.service';
import { catchError, map, Observable, throwError } from 'rxjs';
import { HttpErrorResponse } from '@angular/common/http';
import { DocumentTypeRequest } from '../models/document-type/requests/document-type-request';
import { DocumentTypeResponse } from '../models/document-type/responses/document-type-response';

@Injectable({
  providedIn: 'root'
})
export class DocumentTypeService {

  constructor(private apiCall: GenericApiHandlerService) { }
  create(body: DocumentTypeRequest): Observable<void> {
    return this.apiCall.post<void>('documenttypes', body).pipe(
      catchError((response: HttpErrorResponse) => {
        return throwError(() => response.error.errors)
      })
    )
  }

  getAll(): Observable<DocumentTypeResponse[]> {
    return this.apiCall.get<DocumentTypeResponse[]>('documenttypes').pipe(
      map((response) => {
        return response as DocumentTypeResponse[];
      }),
      catchError((response) => {
        return throwError(() => response.error.errors);
      })
    )
  }

  delete(id: number): Observable<void> {
    return this.apiCall.delete(`documenttypes/${id}`).pipe(
      catchError((response: HttpErrorResponse) => {
        return throwError(() => response.error.errors)
      })
    );
  }
}
