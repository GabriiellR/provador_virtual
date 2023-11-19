using ProvadorVirtual.Dominio.Models;
using ProvadorVirtual.DTO.Administracao;

namespace ProvadorVirtual.Aplicacao.Interfaces.Administracao
{
    public interface IApplicationServiceUsuario : IApplicationServiceBase<UsuarioDTO, Usuario>
    {
        string Autenticar(string email, string senha);
        UsuarioDTO Update(UsuarioDTO dto);
        UsuarioDTO GetUsuarioByEmail(string email);
        void RedefinirSenha(string email);
    }
}
