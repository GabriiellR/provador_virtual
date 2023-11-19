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

        public Usuario GetUsuarioByEmail(string email)
        {
            return _repositoryUsuario.GetUsuarioByEmailAndSenha(email);
        }

        public Usuario GetUsuarioByEmailAndSenha(string email, string senha)
        {
            return _repositoryUsuario.GetUsuarioByEmailAndSenha(email, senha);
        }

        public void SaveChanges()
        {
            _repositoryUsuario.SaveChanges();
        }

        public void Update(Usuario entity)
        {
            _repositoryUsuario.Update(entity);
        }
    }
}
