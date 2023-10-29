using ProvadorVirtual.Dominio.Models;
using ProvadorVirtual.Nucleo.Interfaces.Repositorio.Administracao;
using ProvadorVirtual.Nucleo.Interfaces.Services.Administracao;

namespace ProvadorVirtual.Servicos.Services.Administracao
{
    public class ServiceProdutoImagemProvador : ServiceBase<ProdutoImagensProvador>, IServiceProdutoImagemProvador
    {
        readonly IRepositoryProdutoImagemProvador _repositoryProdutoImagemProvador;
        public ServiceProdutoImagemProvador(IRepositoryProdutoImagemProvador repository) : base(repository)
        {
            _repositoryProdutoImagemProvador = repository;
        }
    }
}
