using AutoMapper;
using AutoMapper.Configuration.Annotations;
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
        readonly IApplicationServiceEmail _applicationServiceEmail;
        readonly IMapper _mapper;
        public ApplicationServiceUsuario(IMapper mapper,
                                         IServiceUsuario serviceUsuario,
                                         IApplicationServiceTokenService applicationServiceTokenService,
                                         IApplicationServiceEmail applicationServiceEmail) : base(mapper, serviceUsuario)
        {
            _serviceUsuario = serviceUsuario;
            _applicationServiceTokenService = applicationServiceTokenService;
            _applicationServiceEmail = applicationServiceEmail;
            _mapper = mapper;
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

        public UsuarioDTO GetUsuarioByEmail(string email)
        {
            var entity = _serviceUsuario.GetUsuarioByEmail(email);
            return _mapper.Map<UsuarioDTO>(entity);
        }

        public void RedefinirSenha(string email)
        {
            var usuario = _serviceUsuario.GetUsuarioByEmail(email);

            if (usuario is null)
                throw new Exception("Usuário não encontrado");

            var novaSenha = GerarSenha();
            usuario.Senha = novaSenha;
            _serviceUsuario.SaveChanges();


            string assunto = "Nova senha TC Gravataria";
            string mensagem = $"Sua nova senha é {novaSenha}";

            _applicationServiceEmail.EnviarEmail(email, assunto, mensagem);
        }

        private string GerarSenha()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new String(stringChars);
        }

        public UsuarioDTO Update(UsuarioDTO dto)
        {
            var enetity = _mapper.Map<Usuario>(dto);
            _serviceUsuario.Update(enetity);
            return dto;
        }
    }
}
