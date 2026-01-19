import { Inject, inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthNavigationService, AuthService } from '@app/shared/data-access';

export const guestGuard: CanActivateFn = (route, state) => {

  const authService = inject(AuthService);
  const router = inject(Router);
  const authNavigationService = inject(AuthNavigationService);

  if (!authService.isLoggedIn)
    return true;

  authNavigationService.redirect();

  return false;
};
