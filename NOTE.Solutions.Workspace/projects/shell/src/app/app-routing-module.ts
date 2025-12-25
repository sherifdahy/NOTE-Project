import { loadRemoteModule } from '@angular-architects/native-federation';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path : '',
    loadChildren : () => loadRemoteModule('landing','./app-Module').then(m => m.AppModule)
  },
  {
    path : 'auth',
    loadChildren : () => loadRemoteModule('auth','./app-Module').then(m => m.AppModule)
  },
  {
    path : 'client',
    loadChildren : () => loadRemoteModule('client','./app-Module').then(m => m.AppModule)
  },
  {
    path : 'system-admin',
    loadChildren : () => loadRemoteModule('systemAdmin','./app-Module').then(m => m.AppModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
