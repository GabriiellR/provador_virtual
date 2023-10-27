﻿using AutoMapper;
using ProvadorVirtual.Dominio.Models;
using ProvadorVirtual.DTO.Administracao;

namespace ProvadorVirtual.Infrastrutura.Crosscutting.Adaptadores.Profiles
{
    public class UsuarioProfile : Profile
    {

        public UsuarioProfile()
        {
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
        }

    }
}