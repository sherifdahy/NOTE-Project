import { Injectable } from '@angular/core';
import { AuthService } from '../../core/services/auth.service';
import { Permission } from '../enums/permissions.enum';
import { Role } from '../enums/role.enum';


@Injectable({ providedIn: 'root' })
export class PermissionService {
  constructor(private auth: AuthService) {}

  // هل عنده الصلاحية دي؟
  can(permission: Permission): boolean {
    const user = this.auth.currentUser;
    if (!user) return false;
    return user.permissions.includes(permission);
  }

  // هل عنده أي صلاحية من دول؟
  canAny(permissions: Permission[]): boolean {
    const user = this.auth.currentUser;
    if (!user) return false;
    return permissions.some(p => user.permissions.includes(p));
  }


}
