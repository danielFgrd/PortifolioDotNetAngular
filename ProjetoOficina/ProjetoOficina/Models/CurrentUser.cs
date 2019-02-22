using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoOficina.ProviderJWT;

namespace ProjetoOficina.Models
{
    public class CurrentUser
    {
        public Usuario Usuario { get; set; }
        public string Token { get; set; }


        public CurrentUser(Usuario usuario, TokenJWT token)
        {
            this.Usuario = usuario;
            this.Token = token.value;
        }
    }
}
