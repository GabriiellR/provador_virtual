using ProvadorVirtual.Data;
using ProvadorVirtual.Dominio.Models;
using ProvadorVirtual.Nucleo.Interfaces.Repositorio.Administracao;

namespace ProvadorVirtual.Repositorio.Administracao
{
    public class RepositoryFavoritos : RepositoryBase<Favoritos>, IRepositoryFavoritos
    {
        readonly Context _context;
        public RepositoryFavoritos(Context context) : base(context)
        {
            _context = context;
        }
    }
}
