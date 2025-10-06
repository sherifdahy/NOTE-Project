import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { GovernorateService } from '../../../../../core/services/governorate.service';
import { NotificationService } from '../../../../../core/services/notification.service';
import { ActivatedRoute, Router } from '@angular/router';
import { CountryResponse } from '../../../../../core/models/country/responses/country-response';
import { CountryService } from '../../../../../core/services/country.service'; // ✅ لو عندك سيرفس للدول

@Component({
  selector: 'app-new-governorate',
  standalone : false,
  templateUrl: './new-governorate.component.html',
  styleUrls: ['./new-governorate.component.css'],
})
export class NewGovernorateComponent implements OnInit {
  countries: CountryResponse[] = [];
  form: FormGroup;

  constructor(
    private fb: FormBuilder,
    private governorateService: GovernorateService,
    private notificationService: NotificationService,
    private router: Router,
    private route: ActivatedRoute,
    private countryService: CountryService
  ) {
    this.form = this.fb.group({
      name: ['', Validators.required],
      code: ['', Validators.required],
      countryId: [0, [Validators.required, Validators.min(1)]],
    });
  }

  ngOnInit() {
    this.loadCountries();
  }

  loadCountries() {
    this.countryService.getAll().subscribe({
      next: (response) => {
        this.countries = response;
      },
      error: (errors) => {
        this.notificationService.showError(errors);
      },
    });
  }

  handleSubmitForm() {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }

    const governorateRequest = this.form.value;

    this.governorateService.create(governorateRequest).subscribe({
      next: () => {
        this.notificationService.showSuccess('تم إنشاء المحافظة بنجاح ✅');
        this.router.navigate(['../'], { relativeTo: this.route });
      },
      error: (errors) => {
        this.notificationService.showError(errors);
      },
    });
  }

  // ميثود مساعدة لتسهيل الوصول لأي control في HTML
  getControl(controlName: string) {
    return this.form.get(controlName);
  }
}
