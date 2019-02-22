import { Component, OnInit, ViewChild } from '@angular/core';
import { UsuarioService } from 'src/app/services/usuario.service';
import { Usuario } from 'src/app/models/usuario.model';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { SharedService } from 'src/app/services/shared.service';

@Component({
  selector: 'app-novo-usuario',
  templateUrl: './novo-usuario.component.html',
  styleUrls: ['./novo-usuario.component.css']
})
export class NovoUsuarioComponent implements OnInit {


  @ViewChild("form")
  form: NgForm;
  private usuario = new Usuario();
  shared: SharedService;
  mensagen: {};
  classCss: {};

  constructor(
    private usuarioService: UsuarioService,
    private route: ActivatedRoute
  ) { }

  findById(id: number){
    this.usuarioService.buscarPorId(id).subscribe((usuario: Usuario) => {
      this.usuario = usuario;
      this.usuario.Senha = '';
    })
  }

  ngOnInit() {
  }

  cadastrar(){
    alert('Acessou o método!')
    this.usuarioService.cadastrar(this.usuario);
  }
}
