using AutoMapper;
using ProvadorVirtual.Dominio.Models;
using ProvadorVirtual.DTO.Administracao;

namespace ProvadorVirtual.Adaptadores.Profiles
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {
            CreateMap<Produto, ProdutoDTO>().ReverseMap();

        }
    }
}
