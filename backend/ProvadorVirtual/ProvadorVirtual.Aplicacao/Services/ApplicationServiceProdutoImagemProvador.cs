using AutoMapper;
using ProvadorVirtual.Aplicacao.Interfaces.Administracao;
using ProvadorVirtual.Dominio.Models;
using ProvadorVirtual.DTO.Administracao;
using ProvadorVirtual.Nucleo.Interfaces.Services.Administracao;

namespace ProvadorVirtual.Aplicacao.Services
{
    public class ApplicationServiceProdutoImagemProvador :
                 ApplicationServiceBase<ProdutoImagemProvadorDTO, ProdutoImagensProvador>, IApplicationServiceProdutoImagemProvador
    {
        readonly IMapper _mapper;
        readonly IServiceProdutoImagemProvador _serviceProdutoImagemProvador;

        public ApplicationServiceProdutoImagemProvador(IMapper mapper, IServiceProdutoImagemProvador service) : base(mapper, service)
        {
            _mapper = mapper;
            _serviceProdutoImagemProvador = service;
        }
    }
}
