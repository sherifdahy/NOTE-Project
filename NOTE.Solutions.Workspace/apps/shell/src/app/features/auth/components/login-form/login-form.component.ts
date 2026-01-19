import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthNavigationService, AuthService, NotificationService } from '@app/shared/data-access';
import { LoginRequest } from '@app/shared/models';

@Component({
  selector: 'app-login-form',
  standalone: false,
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})
export class LoginFormComponent implements OnInit {

  public form!: FormGroup;
  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private notificationService: NotificationService,
    private fb: FormBuilder,
    private authNavigationService: AuthNavigationService,
    private authService: AuthService) { }

  ngOnInit() {
    this.form = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]]
    });
  }

  get email(): FormControl {
    return this.form.get('email') as FormControl;
  }

  get password(): FormControl {
    return this.form.get('password') as FormControl;
  }

  onSubmit() {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }

    const loginRequest = this.form.value as LoginRequest;

    this.authService.login(loginRequest).subscribe({
      next: (response) => {
        const returnUrl = this.activatedRoute.snapshot.paramMap.get('returnUrl');
        this.authNavigationService.redirect(returnUrl);
      },
      error: (error) => {
        this.notificationService.handleError(error);
      }
    });
  }
}
