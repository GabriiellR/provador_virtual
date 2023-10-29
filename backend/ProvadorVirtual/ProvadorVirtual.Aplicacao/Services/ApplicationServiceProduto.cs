using AutoMapper;
using ProvadorVirtual.Aplicacao.Interfaces.Administracao;
using ProvadorVirtual.Dominio.Models;
using ProvadorVirtual.DTO.Administracao;
using ProvadorVirtual.Nucleo.Interfaces.Services.Administracao;

namespace ProvadorVirtual.Aplicacao.Services
{
    public class ApplicationServiceProduto : ApplicationServiceBase<ProdutoDTO, Produto>, IApplicationServiceProduto
    {
        readonly IMapper _mapper;
        readonly IServiceProduto _servoceProduto;
        public ApplicationServiceProduto(IMapper mapper, IServiceProduto serviceProduto) : base(mapper, serviceProduto)
        {
            _mapper = mapper;
            _servoceProduto = serviceProduto;
        }

        public List<ProdutoDTO>? GetWithAllInclude()
        {
            var entityList = _servoceProduto.GetWithAllInclude();
            return _mapper.Map<List<ProdutoDTO>>(entityList);
        }
    }
}
