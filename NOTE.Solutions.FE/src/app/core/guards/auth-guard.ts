import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

export const authGuard: CanActivateFn = (route, state) => {
  const authService = inject(AuthService);
  const router = inject(Router);

  var accessToken = authService.getAccessToken;

  if(!accessToken)
  {
    router.navigateByUrl('auth/login');
    return false;
  }

  return true;
};
