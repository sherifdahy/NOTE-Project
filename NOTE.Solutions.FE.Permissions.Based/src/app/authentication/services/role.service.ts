import { Injectable } from '@angular/core';
import { Role } from '../enums/role.enum';
import { AuthService } from '../../core/services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class RoleService {

  constructor(private authService : AuthService) { }
  // هل عنده الرول ده؟
  hasRole(role: Role): boolean {
    const user = this.authService.currentUser;
    if (!user) return false;
    return user.roles.includes(role);
  }

  // هل عنده أي رول من دول؟
  hasAnyRole(roles: Role[]): boolean {
    const user = this.authService.currentUser;
    if (!user) return false;
    return roles.some(r => user.roles.includes(r));
  }
}
