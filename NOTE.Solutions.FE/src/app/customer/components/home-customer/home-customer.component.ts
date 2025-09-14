import { Component, OnInit } from '@angular/core';
import { CityService } from '../../../core/services/city.service';

@Component({
  selector: 'app-home-customer',
  standalone : false,
  templateUrl: './home-customer.component.html',
  styleUrls: ['./home-customer.component.css']
})
export class HomeCustomerComponent implements OnInit {

  constructor(private cityService : CityService) { }

  ngOnInit() {
    this.cityService.getAll().subscribe({
      next:(response)=>{

        alert(response.length);
      }
    })
  }

}
