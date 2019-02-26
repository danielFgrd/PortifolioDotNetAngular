import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { LoginComponent } from './security/login/login.component';
import { UsuarioService } from './services/usuario.service';
import { HeaderComponent } from './components/header/header.component';
import { MenuMecanicoComponent } from './components/menu-mecanico/menu-mecanico.component';
import { MenuClienteComponent } from './components/menu-cliente/menu-cliente.component';
import { routes } from './app.routes';
import { HttpClient, HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { SharedService } from './services/shared.service';
import { AuthInterceptor } from './security/auth.interceptor';
import { AuthGuard } from './security/auth.guard';
import { HomeComponent } from './components/home/home.component';
import { NovoUsuarioComponent } from './components/novo-usuario/novo-usuario.component';
import { NovoVeiculoComponent } from './components/novo-veiculo/novo-veiculo.component';
import { VeiculoService } from './services/veiculo.service';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HeaderComponent,
    MenuMecanicoComponent,
    MenuClienteComponent,
    HomeComponent,
    NovoUsuarioComponent,
    NovoVeiculoComponent
  ],
  imports: [
    FormsModule,
    BrowserModule,
    HttpClientModule,
    routes
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    },
    AuthGuard,
    VeiculoService,
    UsuarioService,
    SharedService,
    HttpClient
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
