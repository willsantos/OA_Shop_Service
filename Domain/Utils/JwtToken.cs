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
            var key = Encoding.ASCII.GetBytes("U@WJChLSJ&keD^Rg*T6#g@EHwpgaPT2H$tD968a");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                 {
                     //@TODO - Se necessário implementar informações da assinatura e/ou campos solicitados afim de personalizar o token gerado para uso futuro.
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
