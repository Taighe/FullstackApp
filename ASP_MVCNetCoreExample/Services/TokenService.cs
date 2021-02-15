using ASP_MVCNetCoreExample.Interfaces;
using ASP_MVCNetCoreExample.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ASP_MVCNetCoreExample.Services
{
    public class TokenService : ITokenService
    {
        private SymmetricSecurityKey m_key;
        public TokenService(IConfiguration config)
        {
            m_key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
        }

        public string CreateToken(UserModel user)
        {
            var claims = new List<Claim>() { new Claim(JwtRegisteredClaimNames.NameId, user.UserName) };
            var creds = new SigningCredentials(m_key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
