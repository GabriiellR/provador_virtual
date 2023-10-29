using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProvadorVirtual.Aplicacao.Interfaces.Administracao;
using ProvadorVirtual.DTO.Administracao;

namespace ProvadorVirtual.Controllers.Administracao
{
    [ApiController]
    [Route("api/administracao/[controller]")]
    public class FavoritosController : ControllerBase
    {
        readonly IApplicationServiceFavoritos _applicationServiceFavoritos;

        public FavoritosController(IApplicationServiceFavoritos applicationServiceFavoritos)
        {
            _applicationServiceFavoritos = applicationServiceFavoritos;
        }

        [HttpPost]
        [Authorize]
        public ActionResult AddOrUpdate(FavoritosDTO dto)
        {
            if (dto is null)
                return BadRequest("dto nao pode ser nulo");

            var favoritos = _applicationServiceFavoritos.AddOrUpdate(dto);
            return Ok(favoritos);

        }
    }
}
