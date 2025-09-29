import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { inject } from '@angular/core';
import { RoleType } from '../../enums/role-type';

export const alreadyAuthGuard: CanActivateFn = (route, state) => {
  const authService  = inject(AuthService);
  const router = inject(Router);

  let accessToken = authService.getAccessToken;

  if(accessToken)
  {
      let roles = authService.getRoles;

      console.log(roles);

      if(roles?.includes(RoleType[RoleType.Employee]))
        router.navigateByUrl('./employee');
      else if(roles?.includes(RoleType[RoleType.Manager]))
        router.navigateByUrl('./manager');
      else if(roles?.includes(RoleType[RoleType.Addmin]))
        router.navigateByUrl('./admin');
      else
        router.navigateByUrl('not-found');

      return false;
  }

  return true;
};
