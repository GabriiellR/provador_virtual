﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProvadorVirtual.Aplicacao.Interfaces.Administracao;
using ProvadorVirtual.DTO.Administracao;

namespace ProvadorVirtual.Controllers.Administracao
{
    [ApiController]
    [Route("api/administracao/[controller]")]
    public class UsuarioController : ControllerBase
    {
        readonly IApplicationServiceUsuario _applicationServiceUsuario;
        public UsuarioController(IApplicationServiceUsuario applicationServiceUsuario)
        {
            _applicationServiceUsuario = applicationServiceUsuario;
        }


        [HttpPost("autenticar")]
        public ActionResult Autenticar(string email, string senha)
        {
            if (email.IsNullOrEmpty() || senha.IsNullOrEmpty())
                BadRequest("Os campos de email e senha devem ser preenchidos");

            try
            {
                var token = _applicationServiceUsuario.Autenticar(email, senha);
                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        public ActionResult AddOrUpdate(UsuarioDTO dto)
        {
            if (dto is null)
                return BadRequest("O dto não pode ser nulo");

            var usuario = _applicationServiceUsuario.AddOrUpdate(dto);


            return Ok(usuario);
        }
    }
}
