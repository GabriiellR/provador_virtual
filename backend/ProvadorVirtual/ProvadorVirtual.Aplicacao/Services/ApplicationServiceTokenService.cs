using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProvadorVirtual.Aplicacao.Interfaces.Administracao;
using ProvadorVirtual.Dominio.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProvadorVirtual.Aplicacao.Services
{
    public class ApplicationServiceTokenService : IApplicationServiceTokenService
    {
        public string GenerateToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var secret = new ConfigurationBuilder()
                                    .SetBasePath(Directory.GetCurrentDirectory())
                                    .AddJsonFile("appsettings.json").Build().GetSection("secret").Value;

            var key = Encoding.ASCII.GetBytes(secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("id", usuario.Id.ToString()),
                    new Claim("nome", usuario.Nome),
                    new Claim("email", usuario.Nome),
                    new Claim(ClaimTypes.Email, usuario.Email),
                }),

                Expires = DateTime.Now.AddHours(4),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
