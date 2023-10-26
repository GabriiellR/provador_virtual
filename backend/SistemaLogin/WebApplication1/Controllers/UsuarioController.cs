using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.Text;
using System;
using System.Threading.Tasks;
using WebApplication1.Model;
using WebApplication1.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace WebApplication1.Controllers
{
    [ApiController] // Indica que esta classe é um controlador da API.
    [Route("api/[controller]")] // Define a rota base para as ações deste controlador, onde controller será substituído por "UsuarioController".
    public class UsuarioController : ControllerBase
    {
        readonly DataContext _context; // Uma instância do contexto de dados usado para interagir com o banco de dados.
        readonly IConfiguration _configuration; // Uma instância de configuração usada para acessar configurações da aplicação.

        public UsuarioController(DataContext context, IConfiguration configuration)
        {
            this._configuration = configuration;
            this._context = context;
        }

        [HttpGet] // Define um endpoint HTTP GET para esta ação.
        public IActionResult Get()
        {
            var entityList = this._context.Usuarios.ToList();
            return Ok(entityList);
        }

        [AllowAnonymous]  // Permite o acesso a esta ação sem autenticação.
        [HttpPost("register")] // Criação do usuario e Define um endpoint HTTP POST para esta ação com a rota "register".
        public async Task<IActionResult> register([FromForm]Usuario usuario)
        {
            var userExist = await this._context.Usuarios.AsNoTracking()
                   .FirstOrDefaultAsync(o => o.Email.Trim().ToUpper() == usuario.Email.ToUpper().Trim());

            if (userExist is not null)
                return BadRequest(new { Message = "Email já cadastrado!" });

            await this._context.Usuarios.AddAsync(usuario);
            await this._context.SaveChangesAsync();

            return Ok(usuario);
        }


        //Edição de usuarios e atualiza com informações novas
        [HttpPut ("update-user")] // Define um endpoint HTTP PUT para esta ação com a rota "update-user".
        public async Task<IActionResult> Put([FromBody] Usuario user)
        {
            //Passa o email para identificar as alterações 
            var UserData = await this._context.Usuarios.AsNoTracking()
                .FirstOrDefaultAsync(o => o.Email.Trim().ToUpper() == user.Email.Trim().ToUpper());

            if (UserData == null)
                return NotFound(new { sucess = false, Message = "Usuário não encontrado!" });
            user.Id = UserData.Id;

            this._context.Update(user);
            await this._context.SaveChangesAsync();

            return Ok(user);
        }

        //Autenticação 
        //verifica no banco o usuario que tenha o mesmo email e a senha.
        [AllowAnonymous] // Permite o acesso a esta ação sem autenticação.
        [HttpPost("authenticate")] // Define um endpoint HTTP POST para esta ação com a rota "authenticate".
        public async Task<IActionResult> Authenticate([FromForm] Usuario user)
        {
            var userData = this._context.Usuarios.FirstOrDefault(o => o.Email.Trim().ToUpper() == user.Email.ToUpper().Trim()
             && o.password == user.password
            );

            if (userData is null)
                return NotFound(new { Message = "Email ou senha inválidos!" });

            var jwtToken = await GenerateJwtToken(userData);

            return Ok(new { user = jwtToken.user, jwt = jwtToken.token });
        }
        //Gerar o token, caso exista no sistema 
        // Gera um token JWT para um usuário autenticado.
        async Task<(Usuario user, string token)> GenerateJwtToken(Usuario user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["AppSettings:Secret"]); // Obtém a chave secreta para assinar o token a partir das configurações.

            var claims = new ClaimsIdentity(new Claim[]
            {
                        new Claim(ClaimTypes.NameIdentifier, user.Name),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.DateOfBirth, user.YearOfBirth.ToString()),
                        new Claim("UserId", user.Id.ToString()),


            });

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor); // Cria o token JWT.

            return (user, tokenHandler.WriteToken(token)); // Retorna o usuário e o token JWT.

        }

    }
}
