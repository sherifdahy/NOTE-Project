import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { RegisterCompanyRequest } from '../../../../core/models/auth/requests/register-company-request';
import { AuthService } from '../../../../core/services/auth.service';
import { NotificationService } from '../../../../core/services/notification.service';
import { Router } from '@angular/router';
import { ActiveCodeResponse } from '../../../../core/models/active-code/response/active-code-response';
import { ActiveCodeService } from '../../../../core/services/active-code.service';
import { CityResponse } from '../../../../core/models/city/responses/city-response';
import { CityService } from '../../../../core/services/city.service';
import { CountryService } from '../../../../core/services/country.service';
import { GovernorateService } from '../../../../core/services/governorate.service';
import { GovernorateResponse } from '../../../../core/models/governorate/responses/governorate-response';
import { CountryResponse } from '../../../../core/models/country/responses/country-response';

@Component({
  selector: 'app-register-company',
  standalone: false,
  templateUrl: './register-company.component.html',
  styleUrls: ['./register-company.component.css']
})
export class RegisterCompanyComponent implements OnInit {
  activeCodes: ActiveCodeResponse[] = [];
  countries : CountryResponse[] = [];
  governorates: GovernorateResponse[] = [];
  cities: CityResponse[] = [];

  registerForm!: FormGroup;

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

    this.registerForm = fb.group({
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
    return this.registerForm.get('name');
  }

  get rin() {
    return this.registerForm.get('rin');
  }
  get activeCodeId() {
    return this.registerForm.get('activeCodeId');
  }
  get branch() {
    return this.registerForm.get('branch');
  }

  get cityId() {
    return this.registerForm.get('branch')?.get('cityId');
  }
  get code() {
    return this.registerForm.get('branch')?.get('code');
  }
  get applicationUser() {
    return this.registerForm.get('branch')?.get('applicationUser');
  }

  get userName() {
    return this.registerForm.get('branch')?.get('applicationUser')?.get('name');
  }
  get ssn() {
    return this.registerForm.get('branch')?.get('applicationUser')?.get('ssn');
  }
  get phoneNumber() {
    return this.registerForm.get('branch')?.get('applicationUser')?.get('phoneNumber');
  }
  get email() {
    return this.registerForm.get('branch')?.get('applicationUser')?.get('email');
  }
  get password() {
    return this.registerForm.get('branch')?.get('applicationUser')?.get('password');
  }



  handleSubmitForm() {
    if (this.registerForm.invalid) {
      this.registerForm.markAllAsTouched();
      return;
    }
    var companyRequest = this.registerForm.value as RegisterCompanyRequest;

    this.authService.registerCompany(companyRequest).subscribe({
      next: () => {
        this.router.navigateByUrl('auth/login');
      },
      error: (errors) => {
        this.notificationService.showError(errors);
      }
    })

  }

}
