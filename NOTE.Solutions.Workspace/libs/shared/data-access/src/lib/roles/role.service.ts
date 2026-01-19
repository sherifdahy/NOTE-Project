import { Injectable } from '@angular/core';
import { ApiClientService } from '../api/api-client.service';
import { Observable } from 'rxjs';
import { RoleDetailResponse, RoleRequest, RoleResponse } from '@app/shared/models';
import { environment } from 'environments/environment'

@Injectable({
  providedIn: 'root'
})
export class RoleService {

  constructor(private apiCall: ApiClientService) { }

  getAll(includeDisabled: boolean): Observable<RoleResponse[]> {
    return this.apiCall.get(`${environment.apiUrl}/api/roles?includeDisabled=${includeDisabled}`);
  }

  get(id: number): Observable<RoleDetailResponse> {
    return this.apiCall.get(`${environment.apiUrl}/api/roles/${id}`);
  }

  create(request: RoleRequest) {
    return this.apiCall.post(`${environment.apiUrl}/api/roles`, request);
  }

  update(id: number, request: RoleRequest) {
    return this.apiCall.put(`${environment.apiUrl}/api/roles/${id}`, request);
  }

  toggleStatus(id: number) {
    return this.apiCall.delete(`${environment.apiUrl}/api/roles/${id}/toggle-status`);
  }
}
