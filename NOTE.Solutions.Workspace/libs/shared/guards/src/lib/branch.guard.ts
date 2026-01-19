import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { BranchService } from '@app/branches';

export const branchGuard: CanActivateFn = (route, state) => {

  const branchService = inject(BranchService);
  const router = inject(Router);

  if(branchService.currentBranch)
    return true;

  router.navigate(['auth/branch-select'], { queryParams: { returnUrl: state.url } });
  return false;
};
