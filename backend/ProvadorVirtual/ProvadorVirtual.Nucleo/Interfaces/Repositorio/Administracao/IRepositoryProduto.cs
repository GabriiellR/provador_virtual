using ProvadorVirtual.Dominio.Models;

namespace ProvadorVirtual.Nucleo.Interfaces.Repositorio.Administracao
{
    public interface IRepositoryProduto : IRepositoryBase<Produto>
    {
        List<Produto> GetWithAllInclude();
    }
}
