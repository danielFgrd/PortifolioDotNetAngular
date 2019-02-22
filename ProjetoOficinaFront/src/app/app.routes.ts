import { LoginComponent } from './security/login/login.component';
import { RouterModule, Routes, CanActivate } from '@angular/router';
import { ModuleWithProviders } from '@angular/core';
import { AuthGuard } from './security/auth.guard';
import { HomeComponent } from './components/home/home.component';
import { NovoUsuarioComponent } from './components/novo-usuario/novo-usuario.component';

export const ROUTES: Routes = [
  { path: '', component: HomeComponent, canActivate: [AuthGuard] },
  { path: 'login', component: LoginComponent },
  { path: 'novo-usuario', component: NovoUsuarioComponent}
]


export const routes: ModuleWithProviders = RouterModule.forRoot(ROUTES);