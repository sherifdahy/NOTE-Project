import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotFoundComponent } from './pages/not-found/not-found.component';
import { alreadyAuthGuard } from './core/guards/already-auth-guard';
import { EmployeeAuthGuard } from './core/guards/employee-auth-guard';
import { AuthGuard } from './core/guards/auth-guard';
import { AdminAuthGuard } from './core/guards/admin-auth-guard';
import { ManagerAuthGuard } from './core/guards/manager-auth-guard';

const routes: Routes = [
  {
    path : 'manager',
    canActivate : [AuthGuard,ManagerAuthGuard],
    loadChildren : ()=> import('./features/manager/manager.module').then(m=>m.ManagerModule),
  },
  {
    path : 'employee',
    canActivate : [AuthGuard,EmployeeAuthGuard],
    loadChildren : ()=> import('./customer/customer.module').then(m=>m.CustomerModule),
  },
  {
    path : 'admin',
    canActivate : [AuthGuard,AdminAuthGuard],
    loadChildren : ()=> import('./admin/admin.module').then(m=>m.AdminModule),
  },
  {
    path: '',
    canActivate : [alreadyAuthGuard],
    loadChildren: () => import('./features/auth/auth.module').then(m => m.AuthModule)
  },
  {
    path: '**',
    component: NotFoundComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes,{ onSameUrlNavigation: 'reload' })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
