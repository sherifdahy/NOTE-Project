import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { inject } from '@angular/core';

export const alreadyAuthGuard: CanActivateFn = (route, state) => {
  const authService  = inject(AuthService);
  const router = inject(Router);

  let accessToken = authService.getAccessToken;


  if(accessToken)
  {
      router.navigateByUrl('/')
      return false;
  }

  return true;
};
