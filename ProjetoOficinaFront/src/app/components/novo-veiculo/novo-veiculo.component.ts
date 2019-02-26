import { Component, OnInit, ViewChild } from '@angular/core';
import { SharedService } from 'src/app/services/shared.service';
import { VeiculoService } from 'src/app/services/veiculo.service';
import { Usuario } from 'src/app/models/usuario.model';
import { Veiculo } from 'src/app/models/veiculo';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-novo-veiculo',
  templateUrl: './novo-veiculo.component.html',
  styleUrls: ['./novo-veiculo.component.css']
})
export class NovoVeiculoComponent implements OnInit {

  usuario = new Usuario();
  veiculo = new Veiculo();
  shared : SharedService;
  @ViewChild('form')
  form: NgForm;
  classCss : {};
  message : {};
  constructor(
    private veiculoService: VeiculoService,
    private route : Router
  ) { 
    this.shared = SharedService.getInstance();
  }

  ngOnInit() {
  }

  cadastrar(){
    this.veiculo.idProprietario = this.shared.usuario.id;
    this.veiculoService.cadastrar(this.veiculo).subscribe(() => {
      this.form.resetForm();
      this.showMessage({
        type: 'success',
        text: this.veiculo.tipo+' cadastrado com sucesso!'
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