using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using ProvadorVirtual.Aplicacao.Interfaces.Administracao;
using ProvadorVirtual.Dominio.Models;
using ProvadorVirtual.DTO.Administracao;
using ProvadorVirtual.Nucleo.Interfaces.Services.Administracao;

namespace ProvadorVirtual.Aplicacao.Services
{
    public class ApplicationServiceUsuario : ApplicationServiceBase<UsuarioDTO, Usuario>, IApplicationServiceUsuario
    {
        readonly IServiceUsuario _serviceUsuario;
        readonly IApplicationServiceTokenService _applicationServiceTokenService;
        public ApplicationServiceUsuario(IMapper mapper,
                                         IServiceUsuario serviceUsuario,
                                         IApplicationServiceTokenService applicationServiceTokenService) : base(mapper, serviceUsuario)
        {
            _serviceUsuario = serviceUsuario;
            _applicationServiceTokenService = applicationServiceTokenService;
        }

        public string Autenticar(string email, string senha)
        {
            if (email.IsNullOrEmpty() || senha.IsNullOrEmpty())
                throw new Exception("Usuário ou senha nulos");

            var usuario = _serviceUsuario.GetUsuarioByEmailAndSenha(email, senha);

            if (usuario is null)
                throw new Exception("Usuário ou senha inválido");

            var token = _applicationServiceTokenService.GenerateToken(usuario);

            if (token is null)
                throw new Exception("Erro ao gerar token");

            return token;

        }
    }
}
