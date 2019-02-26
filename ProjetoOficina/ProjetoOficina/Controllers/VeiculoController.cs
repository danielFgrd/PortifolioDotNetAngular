using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ProjetoOficina.Models;
using ProjetoOficina.Services;

namespace ProjetoOficina.Controllers
{

    public class VeiculoController : Controller
    {


        [Route("/api/cadastrar/veiculo")]
        [HttpPost]
        [EnableCors("MyPolicy")]
        [Produces("application/json")]
        public IActionResult Cadastrar([FromBody] Veiculo veiculo)
        {
            VeiculoService veiculoService = new VeiculoService();
            veiculoService.Cadastrar(veiculo);

            return Ok();

        }
    }
}