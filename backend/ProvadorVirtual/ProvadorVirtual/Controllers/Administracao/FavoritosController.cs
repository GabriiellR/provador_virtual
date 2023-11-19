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



        [Authorize]
        [HttpGet("{usuarioId}/favoritos")]
        public ActionResult GetByUsuario(int usuarioId)
        {
            if (usuarioId <= 0)
                return BadRequest("Usuário inválido");

          var dto =  _applicationServiceFavoritos.GetByUsuario(usuarioId);

            return Ok(dto);
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddOrUpdate(FavoritosDTO dto)
        {
            if (dto is null)
                return BadRequest("dto nao pode ser nulo");

            var favoritos = _applicationServiceFavoritos.AddOrUpdate(dto);
            return Ok(favoritos);
        }


        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult Delete(FavoritosDTO? dto)
        {
            if (dto is null)
                return BadRequest("O id não pode ser nulo");

            _applicationServiceFavoritos.Remove(dto);

            return Ok();
        }
    }
}
