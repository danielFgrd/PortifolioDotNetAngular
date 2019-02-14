using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Web;

namespace ProjetoOficina.ProviderJWT
{
    public class TokenJWT
    {
        private JwtSecurityToken token;

        public DateTime ValidTo => token.ValidTo;

        public string value => new JwtSecurityTokenHandler().WriteToken(this.token);

        internal TokenJWT(JwtSecurityToken token)
        {
            this.token = token;
        }
    }
}