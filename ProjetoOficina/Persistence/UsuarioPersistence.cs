using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoOficina.Models;

namespace ProjetoOficina.Persistence
{
    public class UsuarioPersistence
    {
        public void Cadastrar(Usuario usuario)
        {
            Persistence<Usuario> persistence = new Persistence<Usuario>(new Usuario());

            persistence.persit(usuario);

        }
    
    }
}