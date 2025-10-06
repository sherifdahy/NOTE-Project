import { Component, OnInit } from '@angular/core';
import { CountryResponse } from '../../../../../core/models/country/responses/country-response';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { GovernorateService } from '../../../../../core/services/governorate.service';
import { NotificationService } from '../../../../../core/services/notification.service';
import { ActivatedRoute, Router } from '@angular/router';
import { CountryService } from '../../../../../core/services/country.service';

@Component({
  selector: 'app-edit-governorate',
  standalone: false,
  templateUrl: './edit-governorate.component.html',
  styleUrls: ['./edit-governorate.component.css']
})
export class EditGovernorateComponent implements OnInit {

  countries: CountryResponse[] = [];
  form: FormGroup;
  currentGovernorateId! : number;
  constructor(
    private fb: FormBuilder,
    private governorateService: GovernorateService,
    private notificationService: NotificationService,
    private router: Router,
    private route: ActivatedRoute,
    private countryService: CountryService
  ) {
    this.currentGovernorateId = Number(this.route.snapshot.paramMap.get('id'));
    this.form = this.fb.group({
      name: ['', Validators.required],
      code: ['', Validators.required],
      countryId: [0, [Validators.required, Validators.min(1)]],
    });
  }

  ngOnInit() {
    this.loadCountries();
    this.loadCurrentGovenorate();
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

  loadCurrentGovenorate(){
    this.governorateService.get(this.currentGovernorateId).subscribe({
      next : (response)=>{
        this.form.setValue({
          name : response.name,
          code : response.code,
          countryId : response.countryId,
        })
      },
      error : (errors)=>{
        this.notificationService.showError(errors);
      }
    })
  }

  handleSubmitForm() {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }

    const governorateRequest = this.form.value;

    this.governorateService.update(this.currentGovernorateId,governorateRequest).subscribe({
      next: () => {
        this.notificationService.showSuccess('تم تعديل المحافظة بنجاح ✅');
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
