using AutoMapper;
using ProvadorVirtual.Dominio.Models;
using ProvadorVirtual.DTO.Administracao;

namespace ProvadorVirtual.Adaptadores.Profiles
{
    public class ProdutoImagemProvadorProfile : Profile
    {
        public ProdutoImagemProvadorProfile()
        {
            CreateMap<ProdutoImagensProvador, ProdutoImagemProvadorDTO>().ReverseMap();
        }
    }
}
