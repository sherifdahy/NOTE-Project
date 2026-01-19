import { Injectable } from '@angular/core';
import { ApiClientService } from '../api/api-client.service';
import { Observable } from 'rxjs';
import { BranchResponse } from '@app/branches';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  constructor(private apiClient: ApiClientService) { }

  getBranches(): Observable<BranchResponse[]> {
    return this.apiClient.get<BranchResponse[]>('branches');
  }
}
