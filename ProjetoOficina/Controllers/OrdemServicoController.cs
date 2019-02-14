using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Web.Mvc;
using ProjetoOficina.Persistence;
using ProjetoOficina.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;




namespace ProjetoOficina.Controllers
{

    [Authorize(Policy = "UsuarioAPI")]
    public class OrdemServicoController : Controller
    {
        
        [HttpGet]
        [Route("api/ApenasUmTeste")]
        public IActionResult SoUmTeste()
        {

            Usuario usuario = new Usuario();

            return Ok(usuario);

        }



    }
}