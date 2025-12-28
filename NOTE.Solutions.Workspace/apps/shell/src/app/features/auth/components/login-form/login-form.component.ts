import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '@invoicing-system/shared/data-access';
import { LoginRequest } from '@invoicing-system/shared/models';

@Component({
  selector: 'app-login-form',
  standalone: false,
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})
export class LoginFormComponent implements OnInit {

  public form!: FormGroup;
  constructor(private fb: FormBuilder, private authService: AuthService) { }

  ngOnInit() {
    this.form = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]]
    });
  }


  onSubmit() {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }

    const loginRequest = this.form.value as LoginRequest;

    this.authService.login(loginRequest).subscribe({
      next: () => {
        alert('Login successful:');
      },
      error: () => {
        alert('Login failed:');
      }
    });
  }
}
