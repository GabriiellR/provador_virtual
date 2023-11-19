using ProvadorVirtual.Dominio.Models;

namespace ProvadorVirtual.Nucleo.Interfaces.Services.Administracao
{
    public interface IServiceUsuario : IServiceBase<Usuario>
    {
        Usuario GetUsuarioByEmail(string email);
        Usuario GetUsuarioByEmailAndSenha(string email, string senha);
        void SaveChanges();
        void Update(Usuario entity);
    }
}
