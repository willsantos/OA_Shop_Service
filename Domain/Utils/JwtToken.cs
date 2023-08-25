using Domain.Contracts.Responses;
using Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Utils
{
    public class JwtToken
    {

        public static JwtTokenResponse GeradorTokenAssinatura(Assinatura assinatura)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("OA_SHOP_JWTKEY"));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                 {
                     new Claim(ClaimTypes.NameIdentifier, assinatura.UsuarioId.ToString()),
                 }),
                Expires = DateTime.UtcNow.AddYears(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new JwtTokenResponse
            {
                Token = tokenHandler.WriteToken(token),
                DataExpiracao = tokenDescriptor.Expires
            };
        }
    }
}
