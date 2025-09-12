import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, retry } from 'rxjs';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class GenericApiHandlerService {

  constructor(private httpclient:HttpClient) { }

  post<TResponse>(url : string,body : any) : Observable<TResponse>{
    return this.httpclient.post<TResponse>(`${environment.baseUrl}/${url}`,body)
  }
}
