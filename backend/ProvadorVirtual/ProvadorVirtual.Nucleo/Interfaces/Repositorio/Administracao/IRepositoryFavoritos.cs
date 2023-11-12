using ProvadorVirtual.Dominio.Models;

namespace ProvadorVirtual.Nucleo.Interfaces.Repositorio.Administracao
{
    public interface IRepositoryFavoritos : IRepositoryBase<Favoritos>
    {
        List<Favoritos> GetByUsuario(int usuarioId);
    }
}
