import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../../../core/services/auth.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { LoginRequest } from '../../../../core/models/auth/requests/login-request';
import { MatSnackBar } from '@angular/material/snack-bar';
import { NotificationService } from '../../../../core/services/notification.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-login-form',
  standalone: false,
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})
export class LoginFormComponent implements OnInit {
  loginForm!: FormGroup;
  constructor(private router: Router, private notificationService: NotificationService, private authService: AuthService, fb: FormBuilder, private snackBar: MatSnackBar) {
    this.loginForm = fb.group({
      email: fb.control('', Validators.required),
      password: fb.control('', Validators.required)
    })
  }

  ngOnInit() {
  }

  get email() {
    return this.loginForm.get('email');
  }

  get password() {
    return this.loginForm.get('password');
  }

  handleSubmitClick() {
    if (!this.loginForm.valid) {
      this.loginForm.markAllAsTouched();
      return;
    }
    let loginRequest = this.loginForm.value as LoginRequest;

    this.authService.login(loginRequest).subscribe({
      next: (response) => {
        this.authService.getRole.subscribe((role) => {
            switch (role?.toLowerCase()) {
              case 'customer': {
                this.router.navigateByUrl('/');
                break;
              }
              case 'admin': {
                this.router.navigateByUrl('/admin');
                break;
              }
          }
        })
      },
      error: (errors) => {
        this.notificationService.showError(errors);
      }
    })
  }
}
