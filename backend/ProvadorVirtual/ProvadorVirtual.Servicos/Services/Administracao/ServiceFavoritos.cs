using ProvadorVirtual.Dominio.Models;
using ProvadorVirtual.Nucleo.Interfaces.Repositorio.Administracao;
using ProvadorVirtual.Nucleo.Interfaces.Services.Administracao;

namespace ProvadorVirtual.Servicos.Services.Administracao
{
    public class ServiceFavoritos : ServiceBase<Favoritos>, IServiceFavoritos
    {
        readonly IRepositoryFavoritos _repositoryFavoritos;
        public ServiceFavoritos(IRepositoryFavoritos repositoryFavoritos) : base(repositoryFavoritos)
        {
            _repositoryFavoritos = repositoryFavoritos;
        }

        public List<Favoritos> GetByUsuario(int usuarioId)
        {
            return _repositoryFavoritos.GetByUsuario(usuarioId);
        }
    }
}
