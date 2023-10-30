using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProvadorVirtual.Aplicacao.Interfaces.Administracao;

namespace ProvadorVirtual.Controllers.Administracao
{
    [ApiController]
    [Route("api/administracao/[controller]")]
    public class ProdutoController : ControllerBase
    {
        readonly IApplicationServiceProduto _applicationServiceProduto;

        public ProdutoController(IApplicationServiceProduto applicationServiceProduto)
        {
            _applicationServiceProduto = applicationServiceProduto;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var produtos = _applicationServiceProduto.GetAll();
            return Ok(produtos);
        }

        [Authorize]
        [HttpGet("detalhes")]
        public ActionResult GetWithAllInclude()
        {
            return Ok(_applicationServiceProduto.GetWithAllInclude());
        }
    }
}
