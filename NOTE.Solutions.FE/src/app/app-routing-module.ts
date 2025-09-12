import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotFoundComponent } from './pages/not-found/not-found.component';
import { authGuard } from './core/guards/auth-guard';
import { alreadyAuthGuard } from './core/guards/already-auth-guard';

const routes: Routes = [
  {
    path: '',
    canActivate: [authGuard],
    loadChildren : ()=> import('./features/dashboard/dashboard.module').then(m=>m.DashboardModule),
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
