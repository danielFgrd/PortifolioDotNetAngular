import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Veiculo } from '../models/veiculo';
import { API } from './projetooficina.api';

@Injectable()
export class VeiculoService {

  constructor(
    private http: HttpClient
  ){
  }

  cadastrar(veiculo: Veiculo){
    return this.http.post(API+'/api/cadastrar/veiculo', veiculo);
  }
}
