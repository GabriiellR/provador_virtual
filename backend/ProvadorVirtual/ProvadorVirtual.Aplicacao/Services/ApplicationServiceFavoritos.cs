using AutoMapper;
using ProvadorVirtual.Aplicacao.Interfaces.Administracao;
using ProvadorVirtual.Dominio.Models;
using ProvadorVirtual.DTO.Administracao;
using ProvadorVirtual.Nucleo.Interfaces.Services.Administracao;

namespace ProvadorVirtual.Aplicacao.Services
{
    public class ApplicationServiceFavoritos : ApplicationServiceBase<FavoritosDTO, Favoritos>, IApplicationServiceFavoritos
    {
        readonly IServiceFavoritos _serviceFavoritos;
        readonly IMapper _mapper;
        public ApplicationServiceFavoritos(IMapper mapper, IServiceFavoritos serviceFavoritos) : base(mapper, serviceFavoritos)
        {
            _serviceFavoritos = serviceFavoritos;
            _mapper = mapper;
        }



        public override FavoritosDTO AddOrUpdate(FavoritosDTO dto)
        {
          
        }

    }
}
