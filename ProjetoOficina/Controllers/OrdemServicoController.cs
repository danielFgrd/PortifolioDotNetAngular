using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using projeto_oficina.Persistence;
using projeto_oficina.Models;
using Newtonsoft.Json;

namespace projeto_oficina.Controllers
{
    public class OrdemServicoController : Controller
    {
        private OrdemServicoPersistence ordemServicoPersistence { get; set; }


        // GET: OrdemServico
        public ActionResult Index()
        {
            return View();
        }


        public void EspecificaDefeito (int idProprietario, int idVeiculo, string defeitoEspecificado)
        {
            ordemServicoPersistence.EspecificarDefeito(idProprietario, idVeiculo, defeitoEspecificado);
        }

        public void AprovarRecusarOrcamento(int id, int idStatusOrcamento)
        {
            ordemServicoPersistence.AprovarRecusarOrcamento(id, idStatusOrcamento);
        }
        public void LiberarVeiculo(int id, string obsLiberacao)
        {
            ordemServicoPersistence.LiberarVeiculo(id, obsLiberacao);
        }

        public void PassarOrcamento(int id, double valor)
        {
            ordemServicoPersistence.PassarOrcamento(id, valor);
        }

        public void AvaliarSituacaoVeiculo(int id, string avaliacaoMecanico)
        {
            ordemServicoPersistence.AvaliarSituacaoVeiculo(id, avaliacaoMecanico);
        }

        public List<OrdemServico> ListarPorProprietario(int idProprietario)
        {
            ordemServicoPersistence.ListarPorProprietario(idProprietario);
            return null;
        }

        public JsonResult Listar()
        {
            ordemServicoPersistence = new OrdemServicoPersistence();
            OrdemServico ordemServico = new OrdemServico();
            ordemServico.Id = 1;
            ordemServico.AvaliacaoMecanico = "fonuncia";
            List<OrdemServico> list = ordemServicoPersistence.Listar();
            list.Add(ordemServico);
            var json = JsonConvert.SerializeObject(list);
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public void AplicarReparo(int id, int idEstado, string descricao)
        {
            ordemServicoPersistence.AplicarReparo(id, idEstado, descricao);
        }
    }
}