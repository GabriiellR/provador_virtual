using ProvadorVirtual.Dominio.Models;
using ProvadorVirtual.DTO.Administracao;

namespace ProvadorVirtual.Aplicacao.Interfaces.Administracao
{
    public interface IApplicationServiceProduto : IApplicationServiceBase<ProdutoDTO, Produto>
    {
        List<ProdutoDTO>? GetWithAllInclude();
    }
}
