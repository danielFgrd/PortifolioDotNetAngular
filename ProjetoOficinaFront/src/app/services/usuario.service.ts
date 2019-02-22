import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders} from '@angular/common/http';
import { PROJETO_OFICINA_API } from './projetooficina.api';
import { Usuario } from '../models/usuario.model';

@Injectable()
export class UsuarioService {

  constructor(
    private http: HttpClient
  ) { }

  login(usuario: Usuario){
    return this.http.post('http://localhost:5000/api/login', usuario);
  }

  buscarPorId(id: number){
    return this.http.post('http://localhost:5000/api/bucarPoId', id);
  }

  cadastrar(usuario: Usuario){
    alert("acessou outro metodo!");
    return this.http.post('http://localhost:5000/api/cadastrar', usuario);
  }
}