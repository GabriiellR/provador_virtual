using ProvadorVirtual.Dominio.Models;
using ProvadorVirtual.DTO.Administracao;

namespace ProvadorVirtual.Aplicacao.Interfaces.Administracao
{
    public interface IApplicationServiceFavoritos : IApplicationServiceBase<FavoritosDTO, Favoritos>
    {
        List<FavoritosDTO> GetByUsuario(int usuarioId);
    }
}
