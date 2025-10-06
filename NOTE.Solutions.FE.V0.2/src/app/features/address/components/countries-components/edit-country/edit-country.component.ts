import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NotificationService } from '../../../../../core/services/notification.service';
import { CountryService } from '../../../../../core/services/country.service';
import { CountryRequest } from '../../../../../core/models/country/requests/country-request';

@Component({
  selector: 'app-edit-country',
  standalone : false,
  templateUrl: './edit-country.component.html',
  styleUrls: ['./edit-country.component.css']
})
export class EditCountryComponent implements OnInit {
  currentCountryId : number;
  form!: FormGroup;
  constructor(private router:Router, private route: ActivatedRoute,private notificationService: NotificationService, private fb: FormBuilder, private countryService: CountryService) {
    this.currentCountryId = Number(this.route.snapshot.paramMap.get('id'));
    this.form = fb.group({
      name: fb.control('', [Validators.required]),
      code: fb.control('', [Validators.required])
    });
  }

  ngOnInit() {
    this.loadCurrentCountry();
  }

  loadCurrentCountry()
  {
    this.countryService.get(this.currentCountryId).subscribe({
      next : (response)=>{
        this.form.setValue({
          name : response.name,
          code : response.code
        })
      },
      error :(errors)=>{
          this.notificationService.showError(errors);
      }
    })
  }
  getControl(controlName: string) {
    return this.form.get(controlName);
  }
  handleSubmitForm() {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }

    let countryRequest = this.form.value as CountryRequest;

    this.countryService.update(this.currentCountryId,countryRequest).subscribe({
      next: () => {
        this.router.navigate(['../'], { relativeTo: this.route });
        this.notificationService.showSuccess('done');
      },
      error: (errors) => {
        this.notificationService.showError(errors);
      }
    });
  }

}
