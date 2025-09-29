import { inject } from '@angular/core';
import { CanActivateFn } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { map } from 'rxjs';
import { RoleType } from '../../enums/role-type';

export const EmployeeAuthGuard: CanActivateFn = (route, state) => {
  const authService = inject(AuthService);

  let roles = authService.getRoles;

  if (roles?.includes(RoleType[RoleType.Employee]))
    return true;
  else
    return false;
};
