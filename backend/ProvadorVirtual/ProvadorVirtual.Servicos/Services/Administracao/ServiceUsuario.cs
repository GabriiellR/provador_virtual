using ProvadorVirtual.Dominio.Models;
using ProvadorVirtual.Nucleo.Interfaces.Repositorio.Administracao;
using ProvadorVirtual.Nucleo.Interfaces.Services.Administracao;

namespace ProvadorVirtual.Servicos.Services.Administracao
{
    public class ServiceUsuario : ServiceBase<Usuario>, IServiceUsuario
    {
        readonly IRepositoryUsuario _repositoryUsuario;
        public ServiceUsuario(IRepositoryUsuario repositoryUsuario) : base(repositoryUsuario)
        {
            _repositoryUsuario = repositoryUsuario;
        }

        public Usuario GetUsuarioByEmailAndSenha(string email, string senha)
        {
            return _repositoryUsuario.GetUsuarioByEmailAndSenha(email, senha);
        }
    }
}
