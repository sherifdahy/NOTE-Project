import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { map } from 'rxjs';
import { RoleType } from '../../enums/role-type';

export const AdminAuthGuard: CanActivateFn = (route, state) => {
  const authService  = inject(AuthService);

  let roles = authService.getRoles;

  if(roles?.includes(RoleType[RoleType.Addmin]))
    return true;
  else
    return false;
};
