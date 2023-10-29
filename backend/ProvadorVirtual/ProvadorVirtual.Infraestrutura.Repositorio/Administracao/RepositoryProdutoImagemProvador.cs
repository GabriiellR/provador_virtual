using ProvadorVirtual.Data;
using ProvadorVirtual.Dominio.Models;
using ProvadorVirtual.Nucleo.Interfaces.Repositorio.Administracao;

namespace ProvadorVirtual.Repositorio.Administracao
{
    public class RepositoryProdutoImagemProvador : RepositoryBase<ProdutoImagensProvador>, IRepositoryProdutoImagemProvador
    {
        readonly Context _context;

        public RepositoryProdutoImagemProvador(Context context) : base(context)
        {
            _context = context;
        }
    }
}
