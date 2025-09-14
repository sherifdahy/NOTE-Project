import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, retry } from 'rxjs';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class GenericApiHandlerService {

  constructor(private httpclient:HttpClient) { }


  private buildHttpOptions (headers?:{[key:string]:string})
  {
    let httpHeaders = new HttpHeaders();

    if(headers)
    {
      for(const key in headers)
      {
        httpHeaders = httpHeaders.set(key,headers[key]);
      }
    }

    return {
      headers,
    }
  }

  post<TResponse>(url : string,body : any,headers?:any) : Observable<TResponse>{
    return this.httpclient.post<TResponse>(`${environment.baseUrl}/${url}`,body,this.buildHttpOptions(headers)).pipe(
      retry(3),
    )
  }

  get<TResponse>(url : string,headers?:any): Observable<TResponse>{
    return this.httpclient.get<TResponse>(`${environment.baseUrl}/${url}`,this.buildHttpOptions(headers));
  }

}
