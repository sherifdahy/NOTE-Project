import { Component, OnInit } from '@angular/core';
import { GovernorateResponse } from '../../../../../core/models/governorate/responses/governorate-response';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NotificationService } from '../../../../../core/services/notification.service';
import { ActivatedRoute, Router } from '@angular/router';
import { GovernorateService } from '../../../../../core/services/governorate.service';
import { CityService } from '../../../../../core/services/city.service';
import { CityRequest } from '../../../../../core/models/city/requests/city-request';

@Component({
  selector: 'app-new-city',
  standalone : false,
  templateUrl: './new-city.component.html',
  styleUrls: ['./new-city.component.css']
})
export class NewCityComponent implements OnInit {

  governorates: GovernorateResponse[] = [];
  form: FormGroup;

  constructor(
    private fb: FormBuilder,
    private governorateService: GovernorateService,
    private notificationService: NotificationService,
    private router: Router,
    private route: ActivatedRoute,
    private cityService: CityService
  ) {
    this.form = this.fb.group({
      name: ['', Validators.required],
      code: ['', Validators.required],
      governorateId: [0, [Validators.required, Validators.min(1)]],
    });
  }

  ngOnInit() {
    this.loadGovernorates();
  }

  loadGovernorates() {
    this.governorateService.getAll().subscribe({
      next: (response) => {
        this.governorates = response;
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

    const request = this.form.value as CityRequest;

    this.cityService.create(request).subscribe({
      next: () => {
        this.notificationService.showSuccess('تم إنشاء المدينة بنجاح ✅');
        this.router.navigate(['../'], { relativeTo: this.route });
      },
      error: (errors) => {
        this.notificationService.showError(errors);
      },
    });
  }

  getControl(controlName: string) {
    return this.form.get(controlName);
  }
}
