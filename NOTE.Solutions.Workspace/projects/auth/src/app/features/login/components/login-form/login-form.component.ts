import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService, ErrorHandlerService} from 'core-lib';
import { LoginRequest } from 'core-lib/lib/models/auth/requests/login-request';

@Component({
  selector: 'app-login-form',
  standalone : false,
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})
export class LoginFormComponent implements OnInit {

  form! : FormGroup;
  constructor(private notificationService: ErrorHandlerService, private fb: FormBuilder,private authService : AuthService) { }

  ngOnInit() {
    this.form = this.fb.group({
      email: ['',[Validators.required, Validators.email]],
      password: ['',[Validators.required, Validators.minLength(6)]]
    });
  }

  onSubmit() {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }


    var request = this.form.value as LoginRequest;

    this.authService.login(request).subscribe({
      next: (response) => {
        console.log('Login successful', response);
      },
      error: (error) => {
        this.notificationService.handleError(error, 'loginForm');
      }
    });
  }
}
