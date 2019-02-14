using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ProjetoOficina.Models;
using ProjetoOficina.ProviderJWT;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjetoOficina.Controllers
{
    public class TokenController : Controller
    {


        [Route("api/CreateToken")]
        [AllowAnonymous]
        [HttpPost]
        [Produces("application/json")]
        public IActionResult CreateToken([FromBody] Usuario user)
        {

            if (user.NomeUsuario != "teste" && user.Senha != "testeSenha")
                return Unauthorized();

            var token = new TokenJWTBuilder()
                .AddSecurityKey(JwtSecurityKey.Create("Secret_Key-70707070"))
                .AddSubject("Valid Ferreira")
                .AddIssuer("Teste.Security.Bearer")
                .AddAudience("Teste.Security.Bearer")
                .AddClaim("UsuarioApiNumero", "1")
                .AddExpiry(5)
                .Builder();

            return Ok(token.value);
        }
    }
}
