import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService, NotificationService } from '@note-solutions-workspace/shared/data-access';
import { ForgetPasswordRequest } from '@note-solutions-workspace/shared/models';

@Component({
  selector: 'app-forget-password',
  standalone: false,
  templateUrl: './forget-password.component.html',
  styleUrls: ['./forget-password.component.css']
})
export class ForgetPasswordComponent implements OnInit {

  form!: FormGroup;
  constructor(private router : Router,private notificationService: NotificationService, private authService: AuthService, private fb: FormBuilder) { }

  ngOnInit() {
    this.form = this.fb.group({
      email: ['', [Validators.required, Validators.email]]
    });
  }

  onSubmit() {
    if (this.form.valid) {
      const request = this.form.value as ForgetPasswordRequest;

      this.authService.forgetPassword(request).subscribe({
        next: (response) => {
          console.log('Password reset link sent:', response);
        },
        error: (error) => {
          this.notificationService.handleError(error, 'forgetPasswordForm');
        }
      });
    }
  }
}
