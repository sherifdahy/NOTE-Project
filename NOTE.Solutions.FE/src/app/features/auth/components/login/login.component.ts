import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NotificationService } from '../../../../core/services/notification.service';
import { AuthService } from '../../../../core/services/auth.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { LoginRequest } from '../../../../core/models/auth/requests/login-request';

@Component({
  selector: 'app-login',
  standalone: false,
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

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
          this.router.navigateByUrl('/manager');
      },
      error: (errors) => {
        this.notificationService.showError(errors);
      }
    })
  }
}
