import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { CountriesComponent } from './components/countries/countries.component';
import { GovernoratesComponent } from './components/governorates/governorates.component';
import { CitiesComponent } from './components/cities/cities.component';

const routes: Routes = [
  {
    path: 'countries',
    children: [
      {
        path: '',
        component: CountriesComponent
      },
    ]
  },
  {
    path: 'governorates',
    children: [
      {
        path: '',
        component: GovernoratesComponent
      },
    ]
  },
  {
    path: 'cities',
    children: [
      {
        path: '',
        component: CitiesComponent
      },
    ]
  }
]


@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
  ],
  declarations: [
    CountriesComponent,
    GovernoratesComponent,
    CitiesComponent
  ]
})
export class AddressModule { }
