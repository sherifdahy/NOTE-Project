import { Component, OnInit } from '@angular/core';
import { CityService } from '../../../../../core/services/city.service';
import { NotificationService } from '../../../../../core/services/notification.service';
import { CityResponse } from '../../../../../core/models/city/responses/city-response';

@Component({
  selector: 'app-cities',
  standalone : false,
  templateUrl: './cities.component.html',
  styleUrls: ['./cities.component.css']
})
export class CitiesComponent implements OnInit {
  cities!: CityResponse[];

  constructor(private cityService: CityService, private notificationService: NotificationService) {
    this.cities = [];
  }

  ngOnInit() {
    this.loadCities();
  }

  loadCities() {
    this.cityService.getAll().subscribe({
      next: (response: CityResponse[]) => this.cities = response,
      error: (err: any) => this.notificationService.showError(err)
    })
  }
}
