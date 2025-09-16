import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { HomeAdminComponent } from './components/home-admin/home-admin.component';
import { MainLayoutComponent } from '../core/layouts/main-layout/main-layout.component';
import { ActiveCodesComponent } from './components/active-codes/active-codes/active-codes.component';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { ActiveCodeDialogComponent } from './components/active-codes/active-code-dialog/active-code-dialog.component';
import { UnitsComponent } from './components/units/units/units.component';
import { DocumentTypesComponent } from './components/document-types/document-types/document-types.component';
import { CountriesComponent } from './components/countries/countries/countries.component';
import { GovernoratesComponent } from './components/governorates/governorates/governorates.component';
import { CitiesComponent } from './components/cities/cities/cities.component';
import { CreateDocumentTypeDialogComponent } from './components/document-types/create-document-type-dialog/create-document-type-dialog.component';

const routes : Routes = [
  {
    path : '',
    component : MainLayoutComponent,
    children : [
      {
        path : '',
        redirectTo : 'home',
        pathMatch : 'full'
      },
      {
        path : 'home',
        component : HomeAdminComponent,
      },
      {
        path : "activecodes",
        component : ActiveCodesComponent
      },
      {
        path : 'units',
        component:UnitsComponent
      },
      {
        path : 'documentTypes',
        component : DocumentTypesComponent
      },
      {
        path : 'countries',
        component : CountriesComponent
      },
      {
        path : 'governorates',
        component : GovernoratesComponent,
      },
      {
        path : 'cities',
        component : CitiesComponent
      }

    ]
  }
]

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    FormsModule,
    ReactiveFormsModule
],
  declarations: [
    ActiveCodesComponent,
    ActiveCodeDialogComponent,
    UnitsComponent,
    DocumentTypesComponent,
    CreateDocumentTypeDialogComponent,
  ]
})
export class AdminModule { }
