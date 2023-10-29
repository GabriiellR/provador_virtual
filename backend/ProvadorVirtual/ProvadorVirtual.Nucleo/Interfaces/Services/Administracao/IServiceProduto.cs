using ProvadorVirtual.Dominio.Models;

namespace ProvadorVirtual.Nucleo.Interfaces.Services.Administracao
{
    public interface IServiceProduto : IServiceBase<Produto>
    {
        List<Produto> GetWithAllInclude();
    }
}
