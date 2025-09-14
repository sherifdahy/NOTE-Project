import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { map } from 'rxjs';

export const adminAuthGuard: CanActivateFn = (route, state) => {
  const authService  = inject(AuthService);

  return authService.getRole.pipe(
    map(role=>{
      if(role?.toLowerCase() == 'admin')
        return true;
      else
        return false;
    })
  )

};
