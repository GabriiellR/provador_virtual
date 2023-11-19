using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProvadorVirtual.Aplicacao.Interfaces.Administracao;

namespace ProvadorVirtual.Controllers.Administracao
{
    [ApiController]
    [Route("api/administracao/[controller]")]
    public class EmailController : ControllerBase
    {

        IApplicationServiceEmail _applicationServiceEmail;

        public EmailController(IApplicationServiceEmail applicationServiceEmail)
        {
            _applicationServiceEmail = applicationServiceEmail;
        }


        [HttpPost]
        public ActionResult EnviarEmail(string destinatario, string? assunto, string? mensagem)
        {
            if (destinatario.IsNullOrEmpty())
                return BadRequest("O destinatario não pode ser nulo");

            _applicationServiceEmail.EnviarEmail(destinatario, assunto, mensagem);

            return Ok("Email enviado com sucesso");
        }

    }
}
