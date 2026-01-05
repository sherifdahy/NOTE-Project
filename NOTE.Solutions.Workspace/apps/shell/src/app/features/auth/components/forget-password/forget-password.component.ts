import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthService, NotificationService } from '@app/shared/data-access';
import { ForgetPasswordRequest } from '@app/shared/models';

@Component({
  selector: 'app-forget-password',
  standalone : false,
  templateUrl: './forget-password.component.html',
  styleUrls: ['./forget-password.component.css']
})
export class ForgetPasswordComponent implements OnInit {

  form!: FormGroup;
  constructor(private notificationService: NotificationService, private authService: AuthService, private fb: FormBuilder) { }

  ngOnInit() {
    this.form = this.fb.group({
      email: ['', [Validators.required, Validators.email]]
    });
  }

  get email(): FormControl {
    return this.form.get('email') as FormControl;
  }
  onSubmit() {
    if (this.form.valid) {
      const request = this.form.value as ForgetPasswordRequest;

      this.authService.forgetPassword(request).subscribe({
        next: () => {

        },
        error: (error) => {
          this.notificationService.handleError(error);
        }
      })
    }
  }


}
