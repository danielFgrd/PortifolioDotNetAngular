using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoOficina.Models;

namespace ProjetoOficina.Repository
{
    public class Usuarios
    {
        public void Cadastrar(Usuario usuario)
        {
            using (var context = new ProjetoOficinaContext())
            {
                var usr = usuario;
                context.Usuario.Add(usr);
                context.SaveChanges();
            }
                                 
        }

        public Usuario Login(Usuario usuario)
        {
            try
            {
                using (var context = new ProjetoOficinaContext())
                {
                    usuario = context.Usuario.Single(u => u.NomeUsuario == usuario.NomeUsuario && u.Senha == usuario.Senha);
                }
            }
            catch(InvalidOperationException e)
            {
                Console.WriteLine(e.Message+ " Usuario ou senha Inválida!");
            }

            return usuario;
        }

    }
}
