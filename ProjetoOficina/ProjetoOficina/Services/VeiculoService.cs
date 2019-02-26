using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoOficina.Repository;
using ProjetoOficina.Models;

namespace ProjetoOficina.Services
{
    public class VeiculoService
    {

        public void Cadastrar(Veiculo veiculo)
        {
            Veiculos veiculos = new Veiculos();
            veiculos.Cadastrar(veiculo);
        }
    }
}
