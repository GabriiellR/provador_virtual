using ProvadorVirtual.Dominio.Models;

namespace ProvadorVirtual.Nucleo.Interfaces.Repositorio.Administracao
{
    public interface IRepositoryUsuario : IRepositoryBase<Usuario>
    {
        Usuario GetUsuarioByEmailAndSenha(string email, string senha);
        Usuario GetUsuarioByEmailAndSenha(string email);
        void SaveChanges();
        void Update(Usuario entity);
    }
}
