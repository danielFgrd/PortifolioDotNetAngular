using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoOficina.Models;

namespace ProjetoOficina.Repository
{
    public class Veiculos
    {
        public void Cadastrar(Veiculo veiculo)
        {
            using (var context = new ProjetoOficinaContext())
            {
                var vei = veiculo;
                context.Veiculo.Add(vei);
                context.SaveChanges();
            }

        }
    }
}
