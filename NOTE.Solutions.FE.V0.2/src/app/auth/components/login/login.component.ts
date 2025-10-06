import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { NotificationService } from '../../../core/services/notification.service';
import { AuthService } from '../../../core/services/auth.service';
import { Role } from '../../../core/enums/role.enum';
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

    this.authService.login(this.email?.value,this.password?.value)?.subscribe({
      next: () => {
          this.router.navigate(['/']);
          return;
      },
      error: (errors : any) => {
        this.notificationService.showError(errors);
      }
    })
  }
}
