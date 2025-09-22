import { inject } from '@angular/core';
import { CanActivateFn } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { map } from 'rxjs';

export const customerAuthGuard: CanActivateFn = (route, state) => {
  const authService = inject(AuthService);

  return authService.getRole.pipe(
      map(role=>{
        if(role?.toLowerCase() == 'customer')
          return true;
        else
          return false;
      })
    )
};
