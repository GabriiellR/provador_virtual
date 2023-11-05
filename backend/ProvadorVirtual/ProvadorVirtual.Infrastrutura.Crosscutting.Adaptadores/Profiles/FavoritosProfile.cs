using AutoMapper;
using ProvadorVirtual.Dominio.Models;
using ProvadorVirtual.DTO.Administracao;

namespace ProvadorVirtual.Adaptadores.Profiles
{
    public class FavoritosProfile : Profile
    {
        public FavoritosProfile()
        {
            CreateMap<Favoritos, FavoritosDTO>().ReverseMap();
        }
    }
}
