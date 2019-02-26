import { Component, OnInit, ViewChild } from '@angular/core';
import { UsuarioService } from 'src/app/services/usuario.service';
import { Usuario } from 'src/app/models/usuario.model';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
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
  message: {};
  classCss: {};

  constructor(
    private usuarioService: UsuarioService,
    private route: Router
  ) { }

  findById(id: number){
    this.usuarioService.buscarPorId(id).subscribe((usuario: Usuario) => {
      this.usuario = usuario;
      this.usuario.senha = '';
    })
  }

  ngOnInit() {
  }

  cadastrar(){
    this.usuarioService.cadastrar(this.usuario).subscribe(() => {
      this.form.resetForm();
      this.showMessage({
        type: 'success',
        text: 'Registrado o '+ this.usuario.nomeCompleto+ ' com sucesso!'
      });
      this.route.navigate['login'];
    }, err => {
      this.showMessage({
        type: 'error',
        text: 'Falha ao cadastrar'
      });
    });
      
  }

  private showMessage(message: {type: string , text: string}): void{
    this.message = message;
    this.buildClasses(message.type);
    setTimeout(() => {
      this.message= undefined;
    }, 3000
    );
  }

  private buildClasses(type: string ): void {
    this.classCss = {
      'alert' : true
    }
    this.classCss['alert-'+type] = true; 
  }
}
