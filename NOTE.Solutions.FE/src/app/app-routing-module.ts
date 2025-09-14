import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotFoundComponent } from './pages/not-found/not-found.component';
import { authGuard } from './core/guards/auth-guard';
import { alreadyAuthGuard } from './core/guards/already-auth-guard';
import { customerAuthGuard } from './core/guards/customer-auth-guard';
import { adminAuthGuard } from './core/guards/admin-auth-guard';

const routes: Routes = [
  {
    path : '',
    canActivate : [authGuard,customerAuthGuard],
    loadChildren : ()=> import('./customer/customer.module').then(m=>m.CustomerModule),
  },
  {
    path : 'admin',
    canActivate : [authGuard,adminAuthGuard],
    loadChildren : ()=> import('./admin/admin.module').then(m=>m.AdminModule),
  },
  {
    path: 'auth',
    canActivate : [alreadyAuthGuard],
    loadChildren: () => import('./features/auth/auth.module').then(m => m.AuthModule)
  },
  {
    path: '**',
    component: NotFoundComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
