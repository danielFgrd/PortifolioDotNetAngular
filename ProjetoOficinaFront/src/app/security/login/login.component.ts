import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/services/shared.service';
import { UsuarioService } from 'src/app/services/usuario.service';
import { Router } from '@angular/router';
import { Usuario } from 'src/app/models/usuario.model';
import { CurrentUser } from 'src/app/models/correntuser.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  usuario= new Usuario();
  shared: SharedService;
  message: string;
  constructor(
    private usuarioService: UsuarioService,
    private router: Router
  ) {
    this.shared = SharedService.getInstance();
   }

  ngOnInit() {
  }

  login(){
    let currentUser = new CurrentUser();
    this.message = '';
    this.usuarioService.login(this.usuario).subscribe((userAuthentication: CurrentUser) =>{
      this.shared.token = userAuthentication.token;
      this.shared.usuario = userAuthentication.usuario;
      this.shared.showTemplate.emit(1);
      this.router.navigate(['/'])
    }, err => {
      this.shared.token = null;
      this.shared.usuario = null;
      this.message = 'Erro';
    });
  }
}
