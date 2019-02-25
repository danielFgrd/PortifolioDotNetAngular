import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders} from '@angular/common/http';
import { PROJETO_OFICINA_API } from './projetooficina.api';
import { Usuario } from '../models/usuario.model';

@Injectable()
export class UsuarioService {

  private readonly API : string = 'http://localhost:5000';

  constructor(
    private http: HttpClient
  ) { }

  login(usuario: Usuario){
    return this.http.post(this.API+'/api/login', usuario);
  }

  buscarPorId(id: number){
    return this.http.post(this.API+'/api/bucarPorId', id);
  }

  cadastrar(usuario: Usuario){
    alert("acessou outro metodo!");
    return this.http.post(this.API+'/api/cadastrar', usuario);
  }
}