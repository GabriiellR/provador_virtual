using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProvadorVirtual.Aplicacao.Interfaces.Administracao;
using ProvadorVirtual.DTO.Administracao;

namespace ProvadorVirtual.Controllers.Administracao
{
    [ApiController]
    [Route("api/administracao/[controller]")]
    public class UsuarioController : ControllerBase
    {
        readonly IApplicationServiceUsuario _applicationServiceUsuario;
        public UsuarioController(IApplicationServiceUsuario applicationServiceUsuario)
        {
            _applicationServiceUsuario = applicationServiceUsuario;
        }

        [HttpPost("redefinirSenha")]
        public ActionResult RedefinirSenha(string? email)
        {
            if (email.IsNullOrEmpty())
                return BadRequest("O e-mail não pode ser nulo");

            try
            {
                _applicationServiceUsuario.RedefinirSenha(email);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }


            return Ok("Senha redefinida");

        }

        [HttpPost("autenticar")]
        public ActionResult Autenticar(string email, string senha)
        {
            if (email.IsNullOrEmpty() || senha.IsNullOrEmpty())
                BadRequest("Os campos de email e senha devem ser preenchidos");

            try
            {
                var token = _applicationServiceUsuario.Autenticar(email, senha);
                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        public ActionResult Add(UsuarioDTO dto)
        {
            if (dto is null)
                return BadRequest("O dto não pode ser nulo");

            if (dto.Id is not null)
                return BadRequest("Método não autorizado");

            var usuario = _applicationServiceUsuario.AddOrUpdate(dto);
            usuario.Senha = "";


            return Ok(usuario);
        }

        [Authorize]
        [HttpPut]
        public ActionResult Update(UsuarioDTO dto)
        {
            if (dto is null)
                return BadRequest("O dto não pode ser nulo");

            if (dto.Id is null)
                return BadRequest("Id não pode ser nulo");

            var usuario = _applicationServiceUsuario.Update(dto);
            usuario.Senha = "";


            return Ok(usuario);
        }

        [Authorize]
        [HttpGet("{usuarioId}")]
        public ActionResult GetById(int usuarioId)
        {
            if (usuarioId <= 0)
                return BadRequest("UsuárioId inválido");

            var usuario = _applicationServiceUsuario.GetById(usuarioId);
            usuario.Senha = "";

            return Ok(usuario);
        }
    }
}
