import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { RoleType } from '../../enums/role-type';

export const ManagerAuthGuard: CanActivateFn = (route, state) => {
  const authService = inject(AuthService);

  let roles = authService.getRoles;

  if(roles?.includes(RoleType[RoleType.Manager]))
    return true;
  else
    return false;

};
