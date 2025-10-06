import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CountriesComponent } from './components/countries-components/countries/countries.component';
import { NewCountryComponent } from './components/countries-components/new-country/new-country.component';
import { EditCityComponent } from './components/cities-components/edit-city/edit-city.component';
import { GovernoratesComponent } from './components/governorates-components/governorates/governorates.component';
import { CitiesComponent } from './components/cities-components/cities/cities.component';
import { NewGovernorateComponent } from './components/governorates-components/new-governorate/new-governorate.component';
import { EditGovernorateComponent } from './components/governorates-components/edit-governorate/edit-governorate.component';
import { NewCityComponent } from './components/cities-components/new-city/new-city.component';
import { EditCountryComponent } from './components/countries-components/edit-country/edit-country.component';

const routes: Routes = [
  {
    path: 'countries',
    children: [
      {
        path: '',
        component: CountriesComponent
      },
      {
        path : 'new',
        component : NewCountryComponent,
      },
      {
        path : ':id',
        component : EditCountryComponent
      }
    ]
  },
  {
    path: 'governorates',
    children: [
      {
        path: '',
        component: GovernoratesComponent
      },
      {
        path : 'new',
        component : NewGovernorateComponent,
      },
      {
        path : ':id',
        component : EditGovernorateComponent
      }
    ]
  },
  {
    path: 'cities',
    children: [
      {
        path: '',
        component: CitiesComponent
      },
      {
        path : 'new',
        component : NewCityComponent,
      },
      {
        path : ':id',
        component : EditCityComponent
      }
    ]
  }
]


@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forChild(routes),
    ReactiveFormsModule
  ],
  declarations: [
    CountriesComponent,
    NewCountryComponent,
    EditCityComponent,
    GovernoratesComponent,
    NewGovernorateComponent,
    EditGovernorateComponent,
    CitiesComponent,
    NewCityComponent,
    EditCountryComponent,
  ]
})
export class AddressModule { }
