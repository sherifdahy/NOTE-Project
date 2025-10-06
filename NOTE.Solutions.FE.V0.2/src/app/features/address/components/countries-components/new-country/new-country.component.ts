import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CountryService } from '../../../../../core/services/country.service';
import { CountryRequest } from '../../../../../core/models/country/requests/country-request';
import { NotificationService } from '../../../../../core/services/notification.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-new-country',
  standalone: false,
  templateUrl: './new-country.component.html',
  styleUrls: ['./new-country.component.css']
})
export class NewCountryComponent implements OnInit {

  form!: FormGroup;
  constructor(private router:Router, private route: ActivatedRoute,private notificationService: NotificationService, private fb: FormBuilder, private countryService: CountryService) {
    this.form = fb.group({
      name: fb.control('', [Validators.required]),
      code: fb.control('', [Validators.required])
    });
  }

  ngOnInit() {
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

    this.countryService.create(countryRequest).subscribe({
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
