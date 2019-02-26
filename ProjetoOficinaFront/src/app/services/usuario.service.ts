import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders} from '@angular/common/http';
import { Usuario } from '../models/usuario.model';
import { API } from './projetooficina.api';

@Injectable()
export class UsuarioService {

  

  constructor(
    private http: HttpClient
  ) { }

  login(usuario: Usuario){
    return this.http.post(API+'/api/login', usuario);
  }

  buscarPorId(id: number){
    return this.http.post(API+'/api/bucarPorId', id);
  }

  cadastrar(usuario: Usuario){
    return this.http.post(API+'/api/cadastrar/usuario', usuario);
  }
}