using AutoMapper;
using ProvadorVirtual.Dominio.Models;
using ProvadorVirtual.DTO.Administracao;

namespace ProvadorVirtual.Adaptadores.Profiles
{
    public class CategoriaProfile :Profile
    {
        public CategoriaProfile()
        {
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
        }

    }
}
