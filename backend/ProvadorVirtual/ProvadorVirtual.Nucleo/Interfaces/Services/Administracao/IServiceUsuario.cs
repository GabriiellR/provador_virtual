using ProvadorVirtual.Dominio.Models;

namespace ProvadorVirtual.Nucleo.Interfaces.Services.Administracao
{
    public interface IServiceUsuario : IServiceBase<Usuario>
    {
        Usuario GetUsuarioByEmailAndSenha(string email, string senha);
        void Update(Usuario entity);
    }
}
