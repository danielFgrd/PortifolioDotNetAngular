using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Web.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoOficina.ProviderJWT;
using ProjetoOficina.Models;
using ProjetoOficina.Services;
using Microsoft.AspNetCore.Cors;
using ProjetoOficina.Responses;

namespace ProjetoOficina.Controllers
{
    public class UsuarioController : Controller
    {

        [Route("/api/login")]
        [AllowAnonymous]
        [HttpPost]
        [EnableCors("MyPolicy")]
        [Produces("application/json")]
        public IActionResult Login([FromBody] Usuario usuario)
        {
            UsuarioService usuarioService = new UsuarioService();

            usuario = usuarioService.Login(usuario);
            
            if (usuario.Id == 0)
                return Unauthorized();

            var token = new TokenJWTBuilder()
                .AddSecurityKey(JwtSecurityKey.Create("Secret_Key-70707070"))
                .AddSubject("Valid Ferreira")
                .AddIssuer("Teste.Security.Bearer")
                .AddAudience("Teste.Security.Bearer")
                .AddClaim("UsuarioApiNumero", "1")
                .AddExpiry(5)
                .Builder();

            CurrentUser currentUser = new CurrentUser(usuario, token);

            return Ok(currentUser);
        }

        [Route("/api/cadastrar")]
        [HttpPost]
        [EnableCors("MyPolicy")]
        [Produces("application/json")]
        public IActionResult Cadastrar([FromBody] Usuario usuario)
        {

            UsuarioService usuarioService = new UsuarioService();
            usuarioService.Cadastrar(usuario);           
                       
            return Ok();
        }
    }
}
