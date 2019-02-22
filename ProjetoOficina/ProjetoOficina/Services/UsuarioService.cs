using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoOficina.Models;
using ProjetoOficina.Repository;

namespace ProjetoOficina.Services
{
    public class UsuarioService
    {
        
        public Usuario Login(Usuario usuario)
        {
            Usuarios usuarios = new Usuarios();
            return usuarios.Login(usuario);
        }

        public void Cadastrar(Usuario usuario)
        {
            Usuarios usuarios = new Usuarios();
            usuarios.Cadastrar(usuario);
        }
    }
}
