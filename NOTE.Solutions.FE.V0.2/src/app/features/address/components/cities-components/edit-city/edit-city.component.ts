import { Component, OnInit } from '@angular/core';
import { GovernorateResponse } from '../../../../../core/models/governorate/responses/governorate-response';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { GovernorateService } from '../../../../../core/services/governorate.service';
import { NotificationService } from '../../../../../core/services/notification.service';
import { ActivatedRoute, Router } from '@angular/router';
import { CityService } from '../../../../../core/services/city.service';
import { CityRequest } from '../../../../../core/models/city/requests/city-request';

@Component({
  selector: 'app-edit-city',
  standalone: false,
  templateUrl: './edit-city.component.html',
  styleUrls: ['./edit-city.component.css']
})
export class EditCityComponent implements OnInit {

  governorates: GovernorateResponse[] = [];
  form: FormGroup;
  currentCityId! : number;
  constructor(
    private fb: FormBuilder,
    private governorateService: GovernorateService,
    private notificationService: NotificationService,
    private router: Router,
    private route: ActivatedRoute,
    private cityService: CityService
  ) {
    this.currentCityId = Number(this.route.snapshot.paramMap.get('id'));
    this.form = this.fb.group({
      name: ['', Validators.required],
      code: ['', Validators.required],
      governorateId: [0, [Validators.required, Validators.min(1)]],
    });
  }

  ngOnInit() {
    this.loadGovernorates();
    this.loadCurrentCity();
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

  loadCurrentCity(){
    this.cityService.get(this.currentCityId).subscribe({
      next :(response)=>{
        this.form.setValue({
          name : response.name,
          code : response.code,
          governorateId : response.governorateId,
        })
      },
      error : ()=>{

      }
    })
  }

  handleSubmitForm() {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }

    const request = this.form.value as CityRequest;

    this.cityService.update(this.currentCityId,request).subscribe({
      next: () => {
        this.notificationService.showSuccess('تم التحديث المدينة بنجاح ✅');
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
