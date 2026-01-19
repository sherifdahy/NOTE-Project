import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '@app/shared/data-access'
import { JwtService } from 'libs/shared/data-access/src/lib/auth/jwt.service';

export const hasContextGuard: CanActivateFn = (route, state) => {

  const authService = inject(AuthService);
  const router = inject(Router);
  const jwtService = inject(JwtService);

  const data = route.data['required-context'] as string;

  const token = authService.currentUser?.token;

  if (token) {
    let contexts = jwtService.decodeToken(token).contexts as string[];
    if (contexts.includes(data))
      return true;
  }
  else {
    router.navigate(['access-denied'], { queryParams: { returnUrl: route.url } });
  }
  return false;
};
