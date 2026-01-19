import { Injectable } from "@angular/core";
import { AuthService } from "./auth.service";
import { Router } from '@angular/router'
import { JwtService } from "./jwt.service";
import { CONTEXT_MAP } from "@app/shared/constants";

@Injectable({ providedIn: 'root' })
export class AuthNavigationService {

  constructor(
    private router: Router,
    private authService: AuthService,
    private jwtService: JwtService
  ) { }

  redirect(returnUrl?: string | null) {

    const token = this.authService.currentUser?.token;

    if (token) {
      const contexts = this.jwtService.decodeToken(token).contexts as string[];

      if (contexts.length === 1) {
        const dashboardId = contexts[0];
        const dashboardPath = CONTEXT_MAP[dashboardId];

        if (dashboardPath) {
          this.router.navigate([dashboardPath]);
          return;
        }
      }
    }

    // Show dashboard selection page if user has multiple contexts or no token
    this.router.navigate(['/auth/select-dashboard'], {
      queryParams: { returnUrl }
    });
  }
}

