import { Component, OnInit } from '@angular/core';
import { CountryService } from '../../../../../core/services/country.service';
import { NotificationService } from '../../../../../core/services/notification.service';
import { CountryResponse } from '../../../../../core/models/country/responses/country-response';

@Component({
  selector: 'app-countries',
  standalone : false,
  templateUrl: './countries.component.html',
  styleUrls: ['./countries.component.css']
})
export class CountriesComponent implements OnInit {
  countries!: CountryResponse[];

  constructor(private countryService: CountryService, private notificationService: NotificationService) {
    this.countries = [];
  }

  ngOnInit() {
    this.loadCountries();
  }

  loadCountries() {
    this.countryService.getAll().subscribe({
      next: (response: CountryResponse[]) => this.countries = response,
      error: (err: any) => this.notificationService.showError(err)
    })
  }

  handleChangeDeletedFilter() {
    this.loadCountries();
  }

  toggleState(id: number) {
    // CountryService doesn't necessarily have toggle in all APIs; if present use it, otherwise do nothing
    if ((this.countryService as any).toggleState) {
      (this.countryService as any).toggleState(id).subscribe({
        next: () => {
          this.loadCountries();
          this.notificationService.showSuccess('تمت العمليه بنجاح');
        },
        error: (e: any) => this.notificationService.showError(e)
      })
    }
  }

}
