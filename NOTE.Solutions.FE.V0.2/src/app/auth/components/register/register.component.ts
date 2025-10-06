import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CountryService } from '../../../core/services/country.service';
import { GovernorateService } from '../../../core/services/governorate.service';
import { CityService } from '../../../core/services/city.service';
import { Router } from '@angular/router';
import { NotificationService } from '../../../core/services/notification.service';
import { AuthService } from '../../../core/services/auth.service';
import { CityResponse } from '../../../core/models/city/responses/city-response';
import { GovernorateResponse } from '../../../core/models/governorate/responses/governorate-response';
import { CountryResponse } from '../../../core/models/country/responses/country-response';
import { RegisterRequest } from '../../../core/models/authentication/requests/register-request';
import { ActiveCodeResponse } from '../../../core/models/active-code/response/active-code-response';
import { ActiveCodeService } from '../../../core/services/active-code.service';

@Component({
  selector: 'app-register',
  standalone: false,
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  activeCodes: ActiveCodeResponse[] = [];
  countries : CountryResponse[] = [];
  governorates: GovernorateResponse[] = [];
  cities: CityResponse[] = [];

  form!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private countryService: CountryService,
    private governorateService: GovernorateService,
    private cityService: CityService,
    private activeCodeService: ActiveCodeService,
    private router: Router,
    private notificationService: NotificationService,
    private authService: AuthService,
  ) {

    this.form = fb.group({
      name: fb.control('', [Validators.required]),
      rin: fb.control('', [Validators.required]),
      activeCodeId: fb.control('', [Validators.required]),
      branch: fb.group({
        cityId: fb.control('', [Validators.required]),
        code: fb.control('', [Validators.required]),
        applicationUser: fb.group({
          name: fb.control('', [Validators.required]),
          ssn: fb.control('', [Validators.required]),
          phoneNumber: fb.control('', [Validators.required]),
          email: fb.control('', [Validators.required]),
          password: fb.control('', [Validators.required]),
        })
      })
    })
  }
  ngOnInit() {
    this.activeCodeService.getAll().subscribe(
      {
        next: (response) => {
          this.activeCodes = response;
        },
        error: (errors) => {
          this.notificationService.showError(errors);
        }
      }
    );

    this.countryService.getAll().subscribe(
      {
        next: (response) => {
          this.countries = response;
        },
        error: (errors) => {
          this.notificationService.showError(errors);
        }
      }
    )

    this.governorateService.getAll().subscribe(
      {
        next: (response) => {
          this.governorates = response;
        },
        error: (errors) => {
          this.notificationService.showError(errors);
        }
      }
    );

    this.cityService.getAll().subscribe(
      {
        next: (response) => {
          this.cities = response;
        },
        error: (errors) => {
          this.notificationService.showError(errors);
        }
      }
    );


  }
  get companyName() {
    return this.form.get('name');
  }

  get rin() {
    return this.form.get('rin');
  }
  get activeCodeId() {
    return this.form.get('activeCodeId');
  }
  get branch() {
    return this.form.get('branch');
  }

  get cityId() {
    return this.form.get('branch')?.get('cityId');
  }
  get code() {
    return this.form.get('branch')?.get('code');
  }
  get applicationUser() {
    return this.form.get('branch')?.get('applicationUser');
  }

  get userName() {
    return this.form.get('branch')?.get('applicationUser')?.get('name');
  }
  get ssn() {
    return this.form.get('branch')?.get('applicationUser')?.get('ssn');
  }
  get phoneNumber() {
    return this.form.get('branch')?.get('applicationUser')?.get('phoneNumber');
  }
  get email() {
    return this.form.get('branch')?.get('applicationUser')?.get('email');
  }
  get password() {
    return this.form.get('branch')?.get('applicationUser')?.get('password');
  }



  handleSubmitForm() {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }
    var companyRequest = this.form.value as RegisterRequest;

    this.authService.register(companyRequest).subscribe({
      next: () => {
        this.router.navigateByUrl('auth/login');
      },
      error: (errors) => {
        this.notificationService.showError(errors);
      }
    })

  }
}
