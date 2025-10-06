import { Injectable } from '@angular/core';
import { Role } from '../enums/role.enum';
import { AuthService } from './auth.service';
import { ApiCallService } from './api-call.service';
import { catchError, map, Observable, throwError } from 'rxjs';
import { RoleResponse } from '../models/role/responses/role-response';

@Injectable({
  providedIn: 'root'
})
export class RoleService {

  constructor(private apiCall: ApiCallService, private authService: AuthService) { }

  getAll(showDeleted : boolean) : Observable<RoleResponse[]>{
    return this.apiCall.get(`api/roles?includeDisabled=${showDeleted}`).pipe(
      map((response) => {
        return response as RoleResponse[];
      }),
      catchError((response) => {
        return throwError(() => response.error.errors);
      })
    )
  }


  hasRole(role: Role): boolean {
    const user = this.authService.currentUser;
    if (!user) return false;
    return user.roles.includes(role);
  }

  hasAnyRole(roles: Role[]): boolean {
    const user = this.authService.currentUser;
    if (!user) return false;
    return roles.some(p => user.roles.includes(p));
  }
}
