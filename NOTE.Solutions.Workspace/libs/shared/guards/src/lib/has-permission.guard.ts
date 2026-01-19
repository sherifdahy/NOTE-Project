import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '@app/shared/data-access';
import { JwtService } from 'libs/shared/data-access/src/lib/auth/jwt.service';

export const hasPermissionGuard: CanActivateFn = (route, state) => {
  const authService = inject(AuthService);
  const router = inject(Router);
  const jwtService = inject(JwtService);

  const data = route.data['required-permission'] as string;

  const token = authService.currentUser?.token;

  if (token) {
    let permissions = jwtService.decodeToken(token).permissions as string[];
    if (permissions.includes(data))
      return true;
  }
  else {
    router.navigate(['access-denied'], { queryParams: { returnUrl: route.url } });
  }
  return false;
};
