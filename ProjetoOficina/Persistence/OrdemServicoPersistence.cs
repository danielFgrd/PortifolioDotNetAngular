using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using projeto_oficina.Models;

namespace projeto_oficina.Persistence
{
    public class OrdemServicoPersistence
    {

        public void EspecificarDefeito(int idProprietario, int idVeiculo, string defeitoEspecificado)
        {
            Persistence<OrdemServico> ordemServicoPersistence = new Persistence<OrdemServico>(new OrdemServico());

            if ((idProprietario != 0) && (idVeiculo != 0) && (defeitoEspecificado != null))
            {
                OrdemServico ordemServico = new OrdemServico();
                
                ordemServico.IdProprietario = idProprietario;
                ordemServico.idVeiculoManutencao = idVeiculo;
                ordemServico.DefeitoEspecificado = defeitoEspecificado;
                ordemServico.IdEstado = 1;

                ordemServicoPersistence.persit(ordemServico);
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public void AprovarRecusarOrcamento(int id, int idEstadoOrcamento)
        {
            Persistence<OrdemServico> persistence = new Persistence<OrdemServico>(new OrdemServico());
            if((id != 0) && (idEstadoOrcamento != 0))
            {
                OrdemServico ordemServico = persistence.findById(id);
                ordemServico.Id = id;
                ordemServico.IdEstadoOrcamento = idEstadoOrcamento;

                persistence.update(ordemServico);
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public void LiberarVeiculo(int id, string obsLiberacao)
        {
            Persistence<OrdemServico> persistence = new Persistence<OrdemServico>(new OrdemServico());
            
            if ((id != 0) && (obsLiberacao != null))
            {
                OrdemServico ordemServico = persistence.findById(id);
                ordemServico.Id = id;
                ordemServico.ObsLiberacao = obsLiberacao;
                persistence.update(ordemServico);
            }
            else
            {
                throw new ArgumentNullException(); 
            }

        }

        public void PassarOrcamento(int id, double valor)
        {
            Persistence<OrdemServico> persistence = new Persistence<OrdemServico>(new OrdemServico());

            if((id != 0) && (valor != 0))
            {
                OrdemServico ordemServico = persistence.findById(id);
                ordemServico.Id = id;
                ordemServico.Orcamento = valor;
                ordemServico.IdEstado = 3;
                persistence.update(ordemServico);

            }
            else
            {
                throw new ArgumentNullException();
            }
        }
               
        public void AvaliarSituacaoVeiculo(int id, string avaliacaoMecanico)
        {
            Persistence<OrdemServico> persistence = new Persistence<OrdemServico>(new OrdemServico());
            
            if((id != 0) && (avaliacaoMecanico != null))
            {
                OrdemServico ordemServico = persistence.findById(id);
                ordemServico.Id = id;
                ordemServico.AvaliacaoMecanico = avaliacaoMecanico;
                ordemServico.IdEstado = 2;
                persistence.update(ordemServico);
            }
            else
            {
                throw new ArgumentNullException();
            }

        }

        public List<OrdemServico> ListarPorProprietario(int idProprietario)
        {
            List<OrdemServico> list = new List<OrdemServico>();
            OrdemServico ordemServico = new OrdemServico();

            Persistence<OrdemServico> persistence = new Persistence<OrdemServico>(new OrdemServico());
            if (idProprietario != 0)
            {
                DataTable dataTable = persistence.GetDataTable("SELECT * FROM OrdemServico WHERE IdProprietario = " + idProprietario + ";");

                foreach (DataRow dataRow in dataTable.Rows)
                {
                    ordemServico.Id = Int32.Parse(dataRow["id"].ToString());
                    ordemServico.IdProprietario = Int32.Parse(dataRow["IdProprietario"].ToString());
                    ordemServico.idVeiculoManutencao = Int32.Parse(dataRow["idVeiculoManutencao"].ToString());
                    ordemServico.IdMecanicoResponsavel = Int32.Parse(dataRow["IdMecanicoResponsavel"].ToString());
                    ordemServico.DefeitoEspecificado = dataRow["DefeitoEspecificado"].ToString();
                    ordemServico.IdEstado = Int32.Parse(dataRow["IdEstado"].ToString());
                    ordemServico.ObsLiberacao = dataRow["ObsLiberacao"].ToString();
                    ordemServico.Orcamento = Double.Parse(dataRow["Orcamento"].ToString());
                    ordemServico.IdEstadoOrcamento = Int32.Parse(dataRow["IdEstadoOrcamento"].ToString());
                }

                list.Add(ordemServico);
            }
            else
            {
                throw new ArgumentNullException();
            }

            return list;    
        }

        public List<OrdemServico> Listar()
        {

            Persistence<OrdemServico> persistence = new Persistence<OrdemServico>(new OrdemServico());

            return persistence.list();

        }

        public void AplicarReparo(int id, int idEstado, string descricao)
        {
            Persistence<OrdemServico> persistence = new Persistence<OrdemServico>(new OrdemServico());
            
            if((id != 0) && (idEstado != 0) && (descricao != null))
            {
                OrdemServico ordemServico = persistence.findById(id);
                ordemServico.Id = id;
                ordemServico.IdEstado = idEstado;
                ordemServico.AvaliacaoMecanico += descricao;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }


    }
}