using Microsoft.EntityFrameworkCore;
using ProvadorVirtual.Data;
using ProvadorVirtual.Dominio.Models;
using ProvadorVirtual.Nucleo.Interfaces.Repositorio.Administracao;

namespace ProvadorVirtual.Repositorio.Administracao
{
    public class RepositoryProduto : RepositoryBase<Produto>, IRepositoryProduto
    {
        readonly Context _context;
        public RepositoryProduto(Context context) : base(context)
        {
            _context = context;
        }

        public List<Produto> GetWithAllInclude()
        {
            return _context.Produto.Include(prop => prop.Categoria).Include(prop => prop.Favoritos).ToList();
        }
    }
}
