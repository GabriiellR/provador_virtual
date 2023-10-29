using ProvadorVirtual.Dominio.Models;
using ProvadorVirtual.Nucleo.Interfaces.Repositorio.Administracao;
using ProvadorVirtual.Nucleo.Interfaces.Services.Administracao;

namespace ProvadorVirtual.Servicos.Services.Administracao
{
    public class ServiceProduto : ServiceBase<Produto>, IServiceProduto
    {
        readonly IRepositoryProduto _repositoryProduto;

        public ServiceProduto(IRepositoryProduto repositoryProduto) : base(repositoryProduto)
        {
            _repositoryProduto = repositoryProduto;
        }

        public List<Produto> GetWithAllInclude()
        {
            return _repositoryProduto.GetWithAllInclude();
        }
    }
}
