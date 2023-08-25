using Domain.Entities;
using Domain.Utils;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Test.Utils
{
    public class JtwTokenTest
    {
        [Fact]
        public void TestGeradorTokenAssinatura()
        {
            var assinatura = new Assinatura
            {
                UsuarioId = new Guid()
            };

            var jwtKey = Environment.GetEnvironmentVariable("OA_SHOP_JWTKEY");
            Environment.SetEnvironmentVariable("OA_SHOP_JWTKEY", jwtKey);

            var expectedExpiration = DateTime.UtcNow.AddYears(1);

            var result = JwtToken.GeradorTokenAssinatura(assinatura);

            Assert.NotNull(result);
            Assert.NotEmpty(result.Token);

            var tolerance = TimeSpan.FromSeconds(1);
            var difference = result.DataExpiracao - expectedExpiration;
            Assert.True(difference <= tolerance, $"A diferença entre as datas é maior do que a tolerância permitida. Diferença: {difference}");


            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtKey)),
                ValidateIssuer = false,
                ValidateAudience = false
            };

            var claimsPrincipal = tokenHandler.ValidateToken(result.Token, validationParameters, out _);

            Assert.True(claimsPrincipal.Identity.IsAuthenticated);
            Assert.Single(claimsPrincipal.Claims, claim => claim.Type == ClaimTypes.NameIdentifier && claim.Value == assinatura.UsuarioId.ToString());
        }
    }
}
