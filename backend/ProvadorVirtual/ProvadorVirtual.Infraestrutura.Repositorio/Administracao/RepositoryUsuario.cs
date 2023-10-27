using ProvadorVirtual.Dominio.Models;
using ProvadorVirtual.Infraestrutura.Data;
using ProvadorVirtual.Nucleo.Interfaces.Repositorio.Administracao;

namespace ProvadorVirtual.Infraestrutura.Repositorio.Administracao
{
    public class RepositoryUsuario : RepositoryBase<Usuario>, IRepositoryUsuario
    {
        readonly Context _contex;
        public RepositoryUsuario(Context context) : base(context)
        {
            _contex = context;
        }

        public Usuario GetUsuarioByEmailAndSenha(string email, string senha)
        {
            return _contex.Usuario
                          .FirstOrDefault(prop => prop.Email.Equals(email) && prop.Senha.Equals(senha));
        }
    }
}
