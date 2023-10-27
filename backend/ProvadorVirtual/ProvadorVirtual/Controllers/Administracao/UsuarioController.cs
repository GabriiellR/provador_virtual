using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProvadorVirtual.Aplicacao.Interfaces.Administracao;

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

        [Authorize]
        [HttpGet("GetAll")]
        public ActionResult GetAll()
        {
            var entity = _applicationServiceUsuario.GetAll();
            return Ok(entity);
        }

        [HttpPost("autenticar")]
        public ActionResult Autenticar(string email, string senha)
        {
            if (email.IsNullOrEmpty() || senha.IsNullOrEmpty())
                BadRequest("Os campos de email e senha devem ser preenchidos");

            var token = _applicationServiceUsuario.Autenticar(email, senha);

            return Ok(token);
        }
    }
}
