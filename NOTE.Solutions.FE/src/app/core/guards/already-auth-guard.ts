import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { inject } from '@angular/core';
import { map } from 'rxjs';

export const alreadyAuthGuard: CanActivateFn = (route, state) => {
  const authService  = inject(AuthService);
  const router = inject(Router);

  return authService.isLogged.pipe(
    map(isLogged => {
      if(isLogged)
      {
        router.navigateByUrl('/')
        return false
      }
      else
        return true;
    })
  )
};
